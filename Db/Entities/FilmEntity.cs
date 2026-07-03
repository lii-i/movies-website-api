public class FilmEntity {
    public int Id {get; set;}
    public string Title {get; set;} = string.Empty;
    public string OriginalTitle {get; set;} = string.Empty;
    public DateOnly DateRelease {get; set;}
    public List<GenreEntity> Genres {get; set;} = new();
    public double Rating {get; set;}
    public int Duration {get; set;}
    public int AgeRating {get; set;}
    public string Country {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public string URLPoster {get; set;} = string.Empty;
    public string URLBackdrop {get; set;} = string.Empty;
    public string Director {get; set;} = string.Empty;
    public int RequestCount {get; set;}
    public List<ActorEntity> Cast {get; set;} = new();
    public string Iframe {get; set;} = string.Empty;
    public bool Featured {get; set;}
}