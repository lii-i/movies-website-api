public class FilmEntity {
    public int Id {get; set;}
    public string Title {get; set;}
    public string OriginalTitle {get; set;}
    public DateOnly DateRelease {get; set;}
    public List<GenreEntity> Genres {get; set;}
    public float Rating {get; set;}
    public int Duration {get; set;}
    public int AgeRating {get; set;}
    public string Country {get; set;}
    public string Description {get; set;}
    public string URLPoster {get; set;}
    public string URLbackdrop {get; set;}
    public string Director {get; set;}
    public int RequestCount {get; set;}
    public List<string> Cast {get; set;} 
    public string Iframe {get; set;}
    public bool Featured {get; set;}
}