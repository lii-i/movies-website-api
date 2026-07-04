using Microsoft.AspNetCore.Mvc;

public static class MoviesEndPoints{
    public static WebApplication AddMoviesEndPoints(this WebApplication app){
        var movieGroup = app.MapGroup("/api/movies");
        
        movieGroup.MapGet("/", async (//FromServices] IRepository rep,
            [FromServices] IAgregatorApiService apiAgregator,
            [FromQuery] string? title = null,
            [FromQuery] string? titleOrig = null,
            [FromQuery] string? types = null,
            [FromQuery] int? year = null,
            [FromQuery] bool? lgbt = null,
            [FromQuery] int? translationId = null,
            [FromQuery] string? translationType = null,
            [FromQuery] string? KinopoiskId = null,
            [FromQuery] string? ImdbId = null,
            [FromQuery] string? ShikimoriId = null,
            [FromQuery] string? AnimeKind = null,
            [FromQuery] int? episode = null,
            [FromQuery] string? animeStatus = null,
            [FromQuery] string? ratingMpaa = null,
            [FromQuery] int? duration = null,
            [FromQuery] double? kinopoiskRating = null,
            [FromQuery] double? ImdbRating = null,
            [FromQuery] double? shikimoriRating = null,
            [FromQuery] int? minimalAge = null,
            [FromQuery] int? lastId = null,
            [FromQuery] int? pageSize = null
            ) =>
        {
            if(!pageSize.HasValue) pageSize = 20;

            apiAgregator.SearchList();


           
        });

        movieGroup.MapGet("/featured", async (//[FromServices] IRepository rep,
            [FromQuery] string? sortBy,
            [FromQuery] int? lastId,
            [FromQuery] int? pageSize) =>
        {
            if(!pageSize.HasValue) pageSize = 20;
            
           
        });

        movieGroup.MapGet("/popular", 
        async (
            //[FromServices] IRepository rep,
            [FromQuery] int? lastId,
            [FromQuery] int? pageSize
        )=>{
           if(!pageSize.HasValue){
            pageSize = 20;
           }


        });

        return app;
    }
}