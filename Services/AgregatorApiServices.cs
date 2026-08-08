using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Polly;
using Polly.Retry;
using Polly.Timeout;
using System.Text.Json;

public interface ISearchService{
    public Task<SearchResponseDTO> SearchAPIAsync(SearchRequestParamDTO searchParam);
    public Task<bool> Ping();
}

public class ApiAgregatorShikimoriKodikSearch: ISearchService{
    private string _kodikToken; 
    private string _shikimoriURL;
    private string _kodikSearchURL;
    private string _kodikSearchListURL;

    private static readonly Dictionary<string, string> GenreMap = new(StringComparer.OrdinalIgnoreCase) {
        ["Экшен"]                = "1-Action",
        ["Экшн"]                 = "1-Action",
        ["Приключения"]          = "2-Adventure",
        ["Машины"]               = "3-Cars",
        ["Комедия"]              = "4-Comedy",
        ["Безумие"]              = "5-Dementia",
        ["Демоны"]               = "6-Demons",
        ["Детектив"]             = "7-Mystery",
        ["Драма"]                = "8-Drama",
        ["Этти"]                 = "9-Ecchi",
        ["Фэнтези"]              = "10-Fantasy",
        ["Игры"]                 = "11-Game",
        ["Хентай"]               = "12-Hentai",
        ["Исторический"]         = "13-Historical",
        ["Ужасы"]                = "14-Horror",
        ["Детское"]              = "15-Kids",
        ["Магия"]                = "16-Magic",
        ["Боевые искусства"]     = "17-Martial Arts",
        ["Меха"]                 = "18-Mecha",
        ["Музыка"]               = "19-Music",
        ["Пародия"]              = "20-Parody",
        ["Самураи"]              = "21-Samurai",
        ["Самурайское"]          = "21-Samurai",
        ["Романтика"]            = "22-Romance",
        ["Школа"]                = "23-School",
        ["Фантастика"]           = "24-Sci-Fi",
        ["Сёдзё"]                = "25-Shoujo",
        ["Сёдзё-ай"]             = "26-Shoujo Ai",
        ["Сёнен"]                = "27-Shounen",
        ["Сёнен-ай"]             = "28-Shounen Ai",
        ["Космос"]               = "29-Space",
        ["Спорт"]                = "30-Sports",
        ["Супер сила"]           = "31-Super Power",
        ["Вампиры"]              = "32-Vampire",
        ["Яой"]                  = "33-Yaoi",
        ["Юри"]                  = "34-Yuri",
        ["Гарем"]                = "35-Harem",
        ["Повседневность"]       = "36-Slice of Life",
        ["Сверхъестественное"]   = "37-Supernatural",
        ["Военное"]              = "38-Military",
        ["Полиция"]              = "39-Police",
        ["Психологическое"]      = "40-Psychological",
        ["Триллер"]              = "41-Thriller",
        ["Сэйнэн"]               = "42-Seinen",
        ["Дзёсей"]               = "43-Josei",
        ["Эротика"]              = "539-Erotica",
        ["Работа"]               = "541-Work Life",
        ["Гурман"]               = "543-Gourmet",
    };

    public ApiAgregatorShikimoriKodikSearch(string kodikToken, string shikimoriURL, string kodikSearchURL, string kodikSearchListURL) {
        _kodikToken = kodikToken;
        _shikimoriURL = shikimoriURL; 
        _kodikSearchURL = kodikSearchURL;
        _kodikSearchListURL = kodikSearchListURL;
    }

    public async Task<SearchResponseDTO> SearchAPIAsync(SearchRequestParamDTO searchParam){
        ShikimoriSearchRequestParamDTO searchParamShikimori = new ShikimoriSearchRequestParamDTO {
            Title = searchParam.Title,
            Limit = searchParam.Limit,
            Rating = searchParam.Rating,
            Page = searchParam.Page,
            Order = searchParam.Order,
            Kind = searchParam.Kind,
            Status = searchParam.Status,
            Season = searchParam.Season,
            Score = searchParam.Score,
            Duration = searchParam.Duration,
            Genre = searchParam.Genre != null && GenreMap.TryGetValue(searchParam.Genre, out var genreId)
                ? genreId
                : searchParam.Genre,
            GenreV2 = searchParam.GenreV2,
            Studio = searchParam.Studio,
            Franchize = searchParam.Franchize,
            Censored = searchParam.Censored,
            Ids = searchParam.Ids,
            ExcludeIds = searchParam.ExcludeIds
        };

        ShikimoriSearchResponseDTO shikimoriResponse = await SearchAsync(searchParamShikimori);
        return MapToResponseDTO(shikimoriResponse);
    }

    private SearchResponseDTO MapToResponseDTO(ShikimoriSearchResponseDTO shikimori)
    {
        return new SearchResponseDTO
        {
           Items =  shikimori.Animes.Select(a => new AnimeResponseDTO
            {
                Id          = Convert.ToInt32(a.Id),
                MalId       = a.MalId != null ? Convert.ToInt32(a.MalId) : null,

                Title         = a.Russian ?? a.Name,         
                OriginalTitle = a.English ?? a.Name,       
                TitleEn       = a.English,
                TitleJap      = a.Japanese,
                Synonyms      = a.Synonyms,

                Poster         = a.Poster?.MainUrl,
                PosterOriginal = a.Poster?.OriginalUrl,
                Backdrop = a.Screenshots.Count > 0
                    ? a.Screenshots[0].OriginalUrl
                    : a.Poster?.OriginalUrl,

                Rating    = a.Score,
                AgeRating = a.Rating, 
                Kind   = a.Kind,
                Status = a.Status,
                Season = a.Season,

                Year       = a.AiredOn?.Year,
                AiredOn    = DateOnly.TryParse(a.AiredOn?.Date, out var aired)    ? aired    : null,
                ReleasedOn = DateOnly.TryParse(a.ReleasedOn?.Date, out var released) ? released : null,

                Episodes      = a.Episodes,
                EpisodesAired = a.EpisodesAired,
                Duration      = a.Duration,

                Genres = a.Genres
                    .Select(g => g.Russian ?? g.Name ?? string.Empty)
                    .Where(g => !string.IsNullOrEmpty(g))
                    .ToList(),

                Studios = a.Studios
                    .Select(s => s.Name ?? string.Empty)
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToList(),

                Director = a.PersonRoles
                    .FirstOrDefault(p => p.RolesEn.Contains("Director"))
                    ?.Person?.Name,


                Cast = a.CharacterRoles
                    .Take(10)
                    .Select(c => c.Character?.Russian ?? c.Character?.Name ?? string.Empty)
                    .Where(n => !string.IsNullOrEmpty(n))
                    .ToList(),

                Description     = a.Description,
                DescriptionHtml = a.DescriptionHtml,
                Censored        = a.IsCensored,

                EmbedUrl = a.PleerLink,

                Screenshots = a.Screenshots
                    .Select(s => s.OriginalUrl ?? string.Empty)
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToList(),

                Related = a.Related
                    .Where(r => r.Anime != null)
                    .Select(r => new RelatedAnimeDTO
                    {
                        Id           = Convert.ToInt32(r.Anime!.Id ?? "0"),
                        Title        = r.Anime.Russian ?? r.Anime.Name ?? string.Empty,
                        RelationKind = r.RelationKind,
                        RelationText = r.RelationText,
                        Poster       = r.Anime.Poster?.OriginalUrl,
                        Rating       = r.Anime.Score,
                        Year         = r.Anime.AiredOn?.Year,
                        Duration     = r.Anime.Duration,
                        Kind         = r.Anime.Kind,
                        Genre        = r.Anime.Genres?.FirstOrDefault()?.Russian ?? r.Anime.Genres?.FirstOrDefault()?.Name
                    })
                    .ToList()

            }).ToList()
        };
    }


    private async Task<ShikimoriSearchResponseDTO> SearchAsync(ShikimoriSearchRequestParamDTO searchParamShikimori){

      string graphqlQuery = @"
    query SearchAnimes(
        $search: String, $limit: Int, $rating: RatingString, $page: Int, 
        $order: OrderEnum, $kind: AnimeKindString, $status: AnimeStatusString, $season: SeasonString, 
        $score: Int, $duration: DurationString, $genre: String, 
        $studio: String, $censored: Boolean, $ids: String
    ) {
        animes(
            search: $search, limit: $limit, rating: $rating, page: $page, 
            order: $order, kind: $kind, status: $status, season: $season, 
            score: $score, duration: $duration, genre: $genre, 
            studio: $studio, censored: $censored, ids: $ids
        ) {
            id malId name russian english japanese synonyms kind rating score status episodes episodesAired duration
            airedOn { year date } 
            releasedOn { date }
            season
            
            poster { originalUrl mainUrl }
            
            isCensored
            genres { name russian }
            studios { name }
            
            screenshots { originalUrl }
            
            personRoles {
                rolesEn
                person { name }
            }
            characterRoles {
                rolesEn
                character { name russian }
            }
            [RELATED_QUERY]
            
            description descriptionHtml
        }
    }"
    .Replace("[RELATED_QUERY]", string.IsNullOrEmpty(searchParamShikimori.Ids) ? "" : @"
            related {
                relationKind relationText
                anime { id name russian kind score duration airedOn { year } poster { originalUrl } genres { name russian } }
            }");

        var payload = new
        {
            query = graphqlQuery,
            variables = searchParamShikimori
        };

        ShikimoriSearchResponseDTO responseShikimori = new ShikimoriSearchResponseDTO();

        try
        {
            ResiliencePipeline<string> piplinePollysShikimori = new ResiliencePipelineBuilder<string>()
            .AddRetry(new RetryStrategyOptions<string> {
                ShouldHandle = new PredicateBuilder<string>().Handle<FlurlHttpException>().Handle<TimeoutRejectedException>(),
                MaxRetryAttempts = 3,
                Delay = TimeSpan.FromSeconds(1),
                BackoffType = DelayBackoffType.Exponential
            })
            .AddTimeout(TimeSpan.FromSeconds(3))
            .Build();

            ResiliencePipeline<KodikSearchResponseDTO> piplinePollysKodik = new ResiliencePipelineBuilder<KodikSearchResponseDTO>()
            .AddRetry(new RetryStrategyOptions<KodikSearchResponseDTO> {
                ShouldHandle = new PredicateBuilder<KodikSearchResponseDTO>().Handle<FlurlHttpException>().Handle<TimeoutRejectedException>(),
                MaxRetryAttempts = 3,
                Delay = TimeSpan.FromSeconds(1),
                BackoffType = DelayBackoffType.Exponential
            })
            .AddTimeout(TimeSpan.FromSeconds(3))
            .Build();

            var rawResponse = await piplinePollysShikimori.ExecuteAsync(async cancellationToken => {
                return await (_shikimoriURL + "/api/graphql")
                .WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36")
                .WithHeader("Accept", "application/json")
                .PostJsonAsync(payload, cancellationToken: cancellationToken)
                .ReceiveString();
            });
            

            var responseFlurl = System.Text.Json.JsonSerializer.Deserialize<GraphQLResponse<ShikimoriSearchResponseDTO>>(rawResponse, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            responseShikimori = responseFlurl.Data;

            for(int i =0; i< responseShikimori.Animes.Count; i++){
                var responseKodik = await piplinePollysKodik.ExecuteAsync(async cancellationToken => {
                   return  await _kodikSearchURL
                    .SetQueryParam("token", _kodikToken)
                    .SetQueryParam("shikimori_id", responseShikimori.Animes[i].Id)
                    .GetAsync()
                    .ReceiveJson<KodikSearchResponseDTO>();
                });
                if(responseKodik != null && responseKodik.Results != null && responseKodik.Results.Count > 0){
                    responseShikimori.Animes[i].PleerLink = responseKodik.Results[0].Link;
                }
            }
            return responseShikimori;
        }
        catch (Exception e) when (e is FlurlHttpException || e is TimeoutRejectedException || e is JsonException)
        {
            throw new Exception("Ошибка со стороны Shikimori или Kodik или сети", e);
        }
    }

    public async Task<bool> Ping()
    {
        ResiliencePipeline pipeline = new ResiliencePipelineBuilder()
            .AddRetry(new RetryStrategyOptions {
                ShouldHandle = new PredicateBuilder().Handle<FlurlHttpException>().Handle<TimeoutRejectedException>(),
                MaxRetryAttempts = 3,
                Delay = TimeSpan.FromSeconds(1),
                BackoffType = DelayBackoffType.Exponential
            })
            .AddTimeout(TimeSpan.FromSeconds(3))
            .Build();

        try
        {
            IFlurlResponse statusShikimori = await pipeline.ExecuteAsync(async cancellationToken => {
                return await _shikimoriURL
                    .WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36")
                    .WithHeader("Accept", "application/json")
                    .GetAsync(cancellationToken: cancellationToken);
            });
            
            IFlurlResponse statusKodik = await pipeline.ExecuteAsync(async cancellationToken => {
                return await _kodikSearchURL
                    .SetQueryParam("token", _kodikToken)
                    .WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36")
                    .WithHeader("Accept", "application/json")
                    .GetAsync(cancellationToken: cancellationToken);
            });
            
            return statusShikimori.IsSuccess && statusKodik.IsSuccess;
        }
        catch (Exception e)
        {
            return false;
        }
    } 
}