public class Repository{

    private CinemaDbContext db;

    public Repository(CinemaDbContext Db){
        db = Db;
    }

    public async Task<List<FilmEntity>> GetFilmsFilter(string[]? genres, int? ageRating, int? yearFrom, int? yearTo, double? minRating, string? sortBy, int? lastId, int pageSize){
        IQueryable<FilmEntity> films = db.Films.Where(f => (genres == null || genres.All(g => f.Genres.Any(dbGenre => dbGenre.Name == g))) && (!ageRating.HasValue || f.AgeRating == ageRating.Value) && (!yearFrom.HasValue || f.DateRelease.Year >= yearFrom.Value) && (!yearTo.HasValue || f.DateRelease.Year <= yearTo.Value) && (!minRating.HasValue || f.Rating > minRating.Value));
       
        FilmEntity? lastFilm = null;

        if(lastId.HasValue && lastId.Value != 0){
            lastFilm = await db.Films.FirstOrDefaultAsync(f => f.Id == lastId);
        }  

        switch(sortBy?.ToLower()){
            case "rating":
                if(lastFilm!= null){
                    films = films.Where(f => f.Rating < lastFilm.Rating || (f.Rating == lastFilm.Rating && f.Id > lastId.Value) );
                }
                films = films.OrderByDescending(f => f.Rating).ThenBy(f => f.Id);
                break;
            case "year":
                if(lastFilm!= null){
                    films = films.Where(f => f.DateRelease < lastFilm.DateRelease || (f.DateRelease == lastFilm.DateRelease && f.Id > lastId.Value) );
                }
                films = films.OrderByDescending(f => f.DateRelease).ThenBy(f => f.Id);
                break;
            case "title": 
                if(lastFilm!= null){
                    films = films.Where(f => string.Compare(f.Title, lastFilm.Title) > 0 || (string.Compare(f.Title, lastFilm.Title) == 0 && f.Id > lastId.Value));
                }
                films = films.OrderBy(f => f.Title).ThenBy(f => f.Id);
                break;
            case "duration":
                if(lastFilm!= null){
                    films = films.Where(f => f.Duration < lastFilm.Duration || (f.Duration == lastFilm.Duration && f.Id > lastId.Value));
                }
                films = films.OrderByDescending(f => f.Duration).ThenBy(f => f.Id);
                break;
            case "popularity":
                if(lastFilm!= null){
                     films = films.Where(f => f.RequestCount < lastFilm.RequestCount || (f.RequestCount == lastFilm.RequestCount && f.Id > lastId.Value));
                }
                films = films.OrderByDescending(f => f.RequestCount).ThenBy(f => f.Id);
                break;
            default:
                if(lastId.HasValue && lastId.Value > 0){
                    films = films.Where(f => f.Id > lastId);
                }
                films = films.OrderBy(f => f.Id);
        }   

        return await films.Take(pageSize).ToListAsync();
    }

    public async Task<int?> GetRequestCount(int id){
        FilmEntity? film = await db.Films.FirstOrDefaultAsync(f => f.Id == id);
        if(film == null) return null;

        return film.RequestCount;
    }

    public async Task<double> GetRequestAverage(){

        return await db.FilmEntity.AverageAsync(f => f.RequestCount);
    }
}