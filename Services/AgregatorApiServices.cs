using Flurl;
using Flurl.Http;

interface IAgregatorApiService{
    public Task<KodikSearchResponse> Search (
    string? title= null, 
    int? limit= null, 
    string? title_orig= null, 
    bool? strict= null, 
    bool? full_match= null, 
    int? shikimori_id= null, 
    int? kinopoisk_id= null, 
    int? imdb_id= null, 
    int? idKodik= null, 
    int? mdl_id= null, 
    string? types= null, 
    int? year= null, 
    int? translation_id= null, 
    string? translation_type= null, 
    string? anime_kind= null, 
    string? anime_status = null);
};

public class ApiKodik: IAgregatorApiService{
    private string _apiToken;

    public ApiKodik (string apiToken){
        _apiToken = apiToken;
    }

    public async Task<KodikSearchResponse> Search (
    string? title= null, 
    int? limit= null, 
    string? title_orig= null, 
    bool? strict= null, 
    bool? full_match= null, 
    int? shikimori_id= null, 
    int? kinopoisk_id= null, 
    int? imdb_id= null, 
    int? idKodik= null, 
    int? mdl_id= null, 
    string? types= null, 
    int? year= null, 
    int? translation_id= null, 
    string? translation_type= null, 
    string? anime_kind= null, 
    string? anime_status = null) {

        var url = "https://kodik-api.com/search"
            .SetQueryParam("token", _apiToken);

        if (title != null)            url = url.SetQueryParam("title", title);
        if (limit != null)            url = url.SetQueryParam("limit", limit);
        if (title_orig != null)       url = url.SetQueryParam("title_orig", title_orig);
        if (strict != null)           url = url.SetQueryParam("strict", strict);
        if (full_match != null)       url = url.SetQueryParam("full_match", full_match);
        if (shikimori_id != null)     url = url.SetQueryParam("shikimori_id", shikimori_id);
        if (kinopoisk_id != null)     url = url.SetQueryParam("kinopoisk_id", kinopoisk_id);
        if (imdb_id != null)          url = url.SetQueryParam("imdb_id", imdb_id);
        if (idKodik != null)          url = url.SetQueryParam("id", idKodik);
        if (mdl_id != null)           url = url.SetQueryParam("mdl_id", mdl_id);
        if (types != null)            url = url.SetQueryParam("types", types);
        if (year != null)             url = url.SetQueryParam("year", year);
        if (translation_id != null)   url = url.SetQueryParam("translation_id", translation_id);
        if (translation_type != null) url = url.SetQueryParam("translation_type", translation_type);
        if (anime_kind != null)       url = url.SetQueryParam("anime_kind", anime_kind);
        if (anime_status != null)     url = url.SetQueryParam("anime_status", anime_status);

        return await url
            .PostAsync()                        
            .ReceiveJson<KodikSearchResponse>();
    }
}