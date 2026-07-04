using Microsoft.AspNetCore.Mvc;

public static class MoviesEndPoints{
    public static WebApplication AddMoviesEndPoints(this WebApplication app){
        var movieGroup = app.MapGroup("/api/movies");
        
        movieGroup.MapGet("/", async (//[FromServices] IRepository rep,
            [FromServices] IAgregatorApiService apiAgregator,
            [FromQuery] string[]? genres,
            [FromQuery] int? ageRating,
            [FromQuery] int? yearFrom,
            [FromQuery] int? yearTo,
            [FromQuery] double? minRating,
            [FromQuery] string? sortBy,
            [FromQuery] int? lastId,
            [FromQuery] int? pageSize) =>
        {
            if(!pageSize.HasValue) pageSize = 20;

           
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