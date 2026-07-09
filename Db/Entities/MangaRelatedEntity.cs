public class MangaRelatedEntity {
    public int Id { get; set; }
    public int MangaId { get; set; }
    public int IdAnimeItem { get; set; }
    public string? RelationKind { get; set; }
    public string? RelationText { get; set; }
}