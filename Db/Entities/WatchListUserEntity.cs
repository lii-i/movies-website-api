public class WatchListUserEntity{
    public int UserId {get; set;}
    public UserEntity User {get; set;}

    public int FilmId {get; set;}
    public FilmEntity Film {get; set;}
}