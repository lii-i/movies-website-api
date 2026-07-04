using Microsoft.AspNetCore.Mvc;

public static class MoviesEndPoints{
    public static WebApplication AddMoviesEndPoints(this WebApplication app){
        var movieGroup = app.MapGroup("/api/movies");
        
        movieGroup.MapGet("/", async (//FromServices] IRepository rep,
            [FromServices] IAgregatorApiService apiAgregator,
            [FromQuery] string? types = null,
            [FromQuery] int? year = null,
            [FromQuery] bool? lgbt = null,
            [FromQuery] int? translationId = null,
            [FromQuery] string? translationType = null,
            [FromQuery] string? AnimeKind = null,
            [FromQuery] int? episode = null,
            [FromQuery] string? animeStatus = null,
            [FromQuery] string? ratingMpaa = null,
            [FromQuery] int? duration = null,
            [FromQuery] string? animeStudios = null,
            [FromQuery] string? genres = null,
            [FromQuery] double? kinopoiskRating = null,
            [FromQuery] double? ImdbRating = null,
            [FromQuery] double? shikimoriRating = null,
            [FromQuery] int? minimalAge = null,
            [FromQuery] int? lastId = null,
            [FromQuery] int? pageSize = null
            ) =>
        {
            if(!pageSize.HasValue) pageSize = 20;

           KodikSearchResponse response = await apiAgregator.SearchList(
            limit: pageSize,
            types: types,
            year: year,
            lgbt: lgbt,
            animeKind: AnimeKind,
            animeStatus: animeStatus,
            ratingMpaa: ratingMpaa,
            minimalAge: minimalAge,
            duration: duration,
            translationId: translationId,
            translationType: translationType,
            animeStudios: animeStudios, 
            genres: genres,             
            kinopoiskRating: kinopoiskRating, 
            imdbRating: ImdbRating,           
            shikimoriRating: shikimoriRating, 
            episode: episode
        );

        return TypedResults.Ok(response);

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