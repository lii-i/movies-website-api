using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

public interface IAgregatorApiService<T>
{
    public Task<SearchResponseDTO<T>> Search(SearchRequestParamDTO searchParam);
}

public class ApiAgregatorShikimoriKodik: IAgregatorApiService<ShikimoriSearchResponseDTO>{
    private string _kodikToken; 
    private string _shikimoriURL;
    private string _kodikSearchURL;
    private string _kodikSearchListURL;

    public ApiAgregatorShikimoriKodik(string kodikToken, string shikimoriURL, string kodikSearchURL, string kodikSearchListURL) {
        _kodikToken = kodikToken;
        _shikimoriURL = shikimoriURL; 
        _kodikSearchURL = kodikSearchURL;
        _kodikSearchListURL = kodikSearchListURL;
    }

    public async Task<SearchResponseDTO<ShikimoriSearchResponseDTO>> Search(SearchRequestParamDTO searchParam){
        KodikSearchRequestParamDTO searchParamKodik = searchParam.searchKodik;
        ShikimoriSearchRequestParamDTO searchParamShikimori = searchParam.searchShikimori;

      string graphqlQuery = @"
    query SearchAnimes(
        $search: String, $limit: Int, $rating: RatingString, $page: Int, 
        $order: OrderEnum, $kind: AnimeKindString, $status: AnimeStatusString, $season: SeasonString, 
        $score: Int, $duration: DurationString, $genre: String, 
        $studio: String, $censored: Boolean
    ) {
        animes(
            search: $search, limit: $limit, rating: $rating, page: $page, 
            order: $order, kind: $kind, status: $status, season: $season, 
            score: $score, duration: $duration, genre: $genre, 
            studio: $studio, censored: $censored
        ) {
            id malId name russian licenseNameRu english japanese synonyms kind rating score status episodes episodesAired duration
            airedOn releasedOn url season
            image { original preview x96 x48 }
            fansubbers fandubbers licensors createdAt updatedAt nextEpisodeAt isCensored
            genres { id name russian kind }
            studios { id name imageUrl }
            externalLinks { id kind url createdAt updatedAt }
            personRoles {
                roles rolesRussian
                person { id name russian url image { original preview x96 x48 } }
            }
            characterRoles {
                roles rolesRussian
                character { 
                    id name russian url altname japanese description descriptionHtml descriptionSource favoured threadId topicId updatedAt
                    image { original preview x96 x48 } 
                }
            }
            related {
                id relationKind relationText
                anime { id name russian english url kind image { original preview x96 x48 } }
                manga { id name russian english url kind image { original preview x96 x48 } }
            }
            videos { id name url imageUrl playerUrl kind }
            screenshots { originalUrl previewUrl }
            scoresStats { score count }
            statusesStats { status count }
            description descriptionHtml descriptionSource
        }
    }";

        var payload = new
        {
            query = graphqlQuery,
            variables = searchParamShikimori
        };

        var finalResponse = new SearchResponseDTO<ShikimoriSearchResponseDTO>();

        try
        {
            var responseShikimori = await _shikimoriURL
            .WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36")
            .WithHeader("Accept", "application/json")
            .PostJsonAsync(payload)
            .ReceiveJson<GraphQLResponse<ShikimoriSearchResponseDTO>>();
           if (responseShikimori.Errors != null && responseShikimori.Errors.Count > 0)
            {
                string errorMessage = responseShikimori.Errors[0].Message;
                throw new Exception($"Ошибка GraphQL API Shikimori: {errorMessage}");
            }
            else
            {
                finalResponse.Response = responseShikimori.Data;
                Console.WriteLine(responseShikimori);
            }

            for(int i =0; i< finalResponse.Response.Animes.Count; i++){
                var responseKodik = await _kodikSearchURL
                .SetQueryParam("token", _kodikToken)
                .SetQueryParam("shikimori_id", finalResponse.Response.Animes[i].Id)
                .GetAsync()
                .ReceiveJson<KodikSearchResponseDTO>();
                
                if(responseKodik != null && responseKodik.Results != null && responseKodik.Results.Count > 0){
                    finalResponse.Response.Animes[i].PleerLink = responseKodik.Results[0].Link;
                }else{
                    finalResponse.Response.Animes.RemoveAt(i);
                }
            }

        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        return finalResponse;
    }
}