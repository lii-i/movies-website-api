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

        return app;

    }
}