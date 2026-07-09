public class ExternalLinksEntity {
    public int Id { get; set; }
    public int IdAnimeItem { get; set; }
    public string Kind { get; set; } = string.Empty; 
    public string Url { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
