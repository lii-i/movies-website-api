public interface IRepository{
    public async Task<List<FilmEntity>> GetFilmsFilter();
    public async Task<int?> GetRequestCount();
    public async Task<double> GetRequestAverage();
}

public class Repository:IRepository{

    private CinemaDbContext _db;

    public Repository(CinemaDbContext DB){
        _db = DB;
    }

    public async Task<List<FilmEntity>> GetFilmsFilter(string[]? genres, int? ageRating, int? yearFrom, int? yearTo, double? minRating, bool? featured, string? sortBy, int? lastId, int pageSize){
        IQueryable<FilmEntity> films = _db.Films.Where(f => (genres == null || genres.All(g => f.Genres.Any(dbGenre => dbGenre.Name == g))) && 
        (!ageRating.HasValue || f.AgeRating == ageRating.Value) && 
        (!yearFrom.HasValue || f.DateRelease.Year >= yearFrom.Value) && 
        (!yearTo.HasValue || f.DateRelease.Year <= yearTo.Value) && 
        (!minRating.HasValue || f.Rating > minRating.Value) &&
        (!featured.HasValue || f.Featured == featured.HasValue)
        )
       
        FilmEntity? lastFilm = null;

        if(lastId.HasValue && lastId.Value != 0){
            lastFilm = await _db.Films.FirstOrDefaultAsync(f => f.Id == lastId);
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
                    films = films.Where(f => f.Id > lastId.Value);
                }
                films = films.OrderBy(f => f.Id);
        }   

        return await films.Take(pageSize).ToListAsync();
    }

    public async Task<int?> GetRequestCount(int id){
        return await _db.Films.Where(f => f.Id == id).Select(f => (int?)f.RequestCount).FirstOrDefault();
    }

    public async Task<double> GetRequestAverage(){

        return await _db.Films.AverageAsync(f => f.RequestCount);
    }
}