public static class MoviesEndPoints{
    public static AddMoviesEndPoints(this WebApplication app){
        var movieGroup = app.MapGroup("/api/movies");
        
        movieGroup.MapGet("/", async ([FromServices] IRepository rep, [FromQuery] string[]? genres, [FromQuery] int? ageRating, [FromQuery] int? yearFrom, [FromQuery] int? yearTo, [FromQuery] double? minRating, [FromQuery] string? sortBy, [ FromQuery] int? lastId, [FromQuery] int? pageSize)=> {
            
            
            if(!pageSize.HasValue) pageSize = 20;
            
            List<FilmEntity> films = await rep.GetFilmsFilter(genres,ageRating,yearFrom,yearTo,minRating,null,sortBy,lastId,pageSize);
            
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
            double AverageRequest = await rep.GetRequestAverage();
            
            List<MovieDTO> movies = films.Select(f => new MovieDTO {
            Id = f.Id, 
            Title = f.Title, 
            OriginalTitle = f.OriginalTitle, 
            DateRelease = f.DateRelease,
            Genres = f.Genres, 
            Rating = f.Rating,
            Duration = f.Duration,
            AgeRating = f.AgeRating,
            Country = f.Country,
            Description = f.Description,
            URLPoster = f.URLPoster,
            URLbackdrop = f.URLbackdrop,
            IsNew = currentDate.DayNumber - f.DateRelease.DayNumber <= 30,
            IsPopular =  f.RequestCount > AverageRequest,
            Featured = f.Featured,
            }).ToList();

            return TypedResults.Ok(movies);
        
        });

        movieGroup.MapGet("/api/movies/featured", ([FromServices] IRepository rep, [FromQuery] string sortBy, [FromQuery] int? lastId, [FromQuery] int? pageSize)=>{

            if(!pageSize.HasValue) pageSize = 20;
            
            List<FilmEntity> films = await rep.GetFilmsFilter(null,null,null,null,null,true,sortBy,lastId,pageSize);
            
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
            double AverageRequest = await rep.GetRequestAverage();
            
            List<MovieDTO> movies = films.Select(f => new MovieDTO {
            Id = f.Id, 
            Title = f.Title, 
            OriginalTitle = f.OriginalTitle, 
            DateRelease = f.DateRelease,
            Genres = f.Genres, 
            Rating = f.Rating,
            Duration = f.Duration,
            AgeRating = f.AgeRating,
            Country = f.Country,
            Description = f.Description,
            URLPoster = f.URLPoster,
            URLbackdrop = f.URLbackdrop,
            IsNew = currentDate.DayNumber - f.DateRelease.DayNumber <= 30,
            IsPopular =  f.RequestCount > AverageRequest,
            Featured = f.Featured,
            }).ToList();

            return TypedResults.Ok(movies);
        

        })

    }
}