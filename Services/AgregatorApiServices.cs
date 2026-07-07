using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

public interface IAgregatorApiService<Res,Req>
{
    public Task<SearchResponseDTO<Res>> Search(SearchRequestParamDTO<Req> searchParam);
}

public class ApiAgregatorShikimoriKodik: IAgregatorApiService<ShikimoriSearchResponseDTO, ShikimoriSearchRequestParamDTO>{
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

    public async Task<SearchResponseDTO<ShikimoriSearchResponseDTO>> Search(SearchRequestParamDTO<ShikimoriSearchRequestParamDTO> searchParam){
        
        ShikimoriSearchRequestParamDTO searchParamShikimori = searchParam.SearchRequestParam;

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
            airedOn { year month day date } 
            releasedOn { year month day date }
            url season
            
            poster { id originalUrl mainUrl }
            
            fansubbers fandubbers licensors createdAt updatedAt nextEpisodeAt isCensored
            genres { id name russian kind }
            studios { id name imageUrl }
            externalLinks { id kind url createdAt updatedAt }
            
            screenshots { id originalUrl x166Url x332Url }
            
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
                    i--;
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