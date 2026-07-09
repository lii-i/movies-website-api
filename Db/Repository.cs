public interface IRepository {
    public void InsertAnime(AnimeItemsEntity anime);
}

public class Repository : IRepository {
    private CinemaDbContext _db;

    public Repository(CinemaDbContext db){
        _db = db;
    }

    public void InsertAnime(AnimeItemsEntity anime){
        _db.AnimeItems.Add(anime);
        _db.SaveChanges();
    }
}