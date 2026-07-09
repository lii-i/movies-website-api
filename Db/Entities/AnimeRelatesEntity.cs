public class AnimeRelatesEntity {
    public int Id { get; set; }
    public int IdAnime1 { get; set; }
    public int IdAnime2 { get; set; }
    public string? RelationKind { get; set; }
    public string? RelationText { get; set; }
}