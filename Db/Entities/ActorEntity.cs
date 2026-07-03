public class ActorEntity {
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;

    public List<FilmEntity> Films {get; set;} = new();
}
