using Microsoft.AspNetCore.Mvc;

public static class MoviesEndPoints{
    public static WebApplication AddMoviesEndPoints(this WebApplication app){
        app.MapGet("/search", async (
        [FromServices] IAgregatorApiService<ShikimoriSearchResponseDTO> ApiAgregator,
        [FromQuery] string? title,
        [FromQuery] int? limit,
        [FromQuery] double? ratingDown,
        [FromQuery] double? ratingHight,
        [FromQuery] string[]? genres,
        [FromQuery] string? mpaaRating
        ) =>{
            SearchRequestParamDTO searchParam = new SearchRequestParamDTO();
            searchParam.searchShikimori = new ShikimoriSearchRequestParamDTO{
                Title = title,
                Limit = limit
            };

            var response = await ApiAgregator.Search(searchParam);
            Console.WriteLine(response);

            return TypedResults.Ok(response.Response);
            

        });

        return app;

    }
}