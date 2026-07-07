using Microsoft.AspNetCore.Mvc;

public static class MoviesEndPoints{
    public static WebApplication AddMoviesEndPoints(this WebApplication app){
        app.MapGet("/search", async (
        [FromServices] IAgregatorApiService<ShikimoriSearchResponseDTO, ShikimoriSearchRequestParamDTO> ApiAgregator,
        [FromQuery(Name="title")] string? title,
        [FromQuery(Name="limit")] int? limit,
        [FromQuery(Name="minRating")] int? minRating,
        [FromQuery(Name="duration")] string? duration, 
        [FromQuery(Name="genres")] string? genres,
        [FromQuery(Name="mpaaRating")] string? mpaaRating
        ) =>{
            SearchRequestParamDTO<ShikimoriSearchRequestParamDTO> searchParam = new SearchRequestParamDTO<ShikimoriSearchRequestParamDTO>();
            searchParam.SearchRequestParam = new ShikimoriSearchRequestParamDTO{
                Title = title,
                Limit = limit,
                Score = minRating,
                Duration = duration,
                Genre = genres,
                Rating = mpaaRating
            };

            var response = await ApiAgregator.Search(searchParam);
            Console.WriteLine(response);

            return TypedResults.Ok(response.Response);
            

        });

        return app;

    }
}