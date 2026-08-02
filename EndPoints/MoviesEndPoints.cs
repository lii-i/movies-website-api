using Microsoft.AspNetCore.Mvc;
    public static class MoviesEndPoints{
        public static WebApplication AddMoviesEndPoints(this WebApplication app){
       
        app.MapGet("/search", async (
        [FromServices] ISearchService ApiAgregator,
        [FromServices] AnimeService animeService,
        [FromQuery(Name="title")]     string? title,
        [FromQuery(Name="limit")]     int?    limit,
        [FromQuery(Name="page")]      int?    page,
        [FromQuery(Name="minRating")] int?    minRating,
        [FromQuery(Name="duration")]  string? duration,
        [FromQuery(Name="genres")]    string? genres,
        [FromQuery(Name="mpaaRating")]string? mpaaRating,
        [FromQuery(Name="order")]     string? order,
        [FromQuery(Name="kind")]      string? kind,
        [FromQuery(Name="status")]    string? status
        ) =>{

            SearchRequestParamDTO searchParam = new SearchRequestParamDTO {
                Title    = title,
                Limit    = limit,
                Page     = page,
                Score    = minRating,
                Duration = duration,
                Genre    = genres,
                Rating   = mpaaRating,
                Order    = order,
                Kind     = kind,
                Status   = status
            };

            SearchResponseDTO responseAPI = await ApiAgregator.SearchAPIAsync(searchParam);

            animeService.AddOrUpdateAnimeAsync(responseAPI);

            return TypedResults.Ok(responseAPI);

        });

    app.MapGet("api/movies/{id}", async(
    string id,
    [FromServices] ISearchService ApiAgregator,
    [FromServices] AnimeService animeService
    ) => {
        SearchRequestParamDTO requestParam = new SearchRequestParamDTO {
            Ids = id
        };

        SearchResponseDTO responseAPI = await ApiAgregator.SearchAPIAsync(requestParam);
        var anime = responseAPI.Items.FirstOrDefault();

        if (anime == null) {
            return Results.NotFound();
        }

        return Results.Ok(anime);
    });

    app.MapGet("api/movies/{id}/related", async(
    string id,
    [FromServices] ISearchService ApiAgregator
    ) => {
        SearchRequestParamDTO requestParam = new SearchRequestParamDTO {
            Ids = id
        };

        SearchResponseDTO responseAPI = await ApiAgregator.SearchAPIAsync(requestParam);
        var anime = responseAPI.Items.FirstOrDefault();

        if (anime != null && anime.Related != null) {
            return Results.Ok(anime.Related);
        }

        return Results.Ok(new List<RelatedAnimeDTO>());
    });

    return app;
    }
}