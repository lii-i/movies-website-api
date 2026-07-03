public record MovieDTO {
    public int Id {get; init;}
    public string Title {get; init;} = string.Empty;
    public string OriginalTitle {get; init;} = string.Empty;
    public DateOnly DateRelease {get; init;}
    public List<GenreEntity> Genres {get; init;} = new();
    public double Rating {get; init;}
    public int Duration {get; init;}
    public int AgeRating {get; init;}
    public string Country {get; init;} = string.Empty;
    public string Description {get; init;} = string.Empty;
    public string URLPoster {get; init;} = string.Empty;
    public string URLBackdrop {get; init;} = string.Empty;
    public List<string> Cast {get; init;} = new();
    public bool IsNew {get; init;}
    public bool IsPopular {get; init;}
    public bool Featured {get; init;}
}