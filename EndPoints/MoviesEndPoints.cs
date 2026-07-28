using Microsoft.AspNetCore.Mvc;
    public static class MoviesEndPoints{
        public static WebApplication AddMoviesEndPoints(this WebApplication app){
       
        app.MapGet("/search", async (
        [FromServices] ISearchService ApiAgregator,
        [FromQuery(Name="title")] string? title,
        [FromQuery(Name="limit")] int? limit,
        [FromQuery(Name="minRating")] int? minRating,
        [FromQuery(Name="duration")] string? duration, 
        [FromQuery(Name="genres")] string? genres,
        [FromQuery(Name="mpaaRating")] string? mpaaRating
        ) =>{

            SearchRequestParamDTO searchParam = new SearchRequestParamDTO {
                Title = title,
                Limit = limit,
                Score = minRating,
                Duration = duration,
                Genre = genres,
                Rating = mpaaRating
            };

            SearchResponseDTO responseAPI = await ApiAgregator.SearchAPIAsync(searchParam);
            
            return TypedResults.Ok(responseAPI);


        });

        return app;

    }
}