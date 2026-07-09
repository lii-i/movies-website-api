public class AnimeItemsEntity {
    public int Id { get; set; }
    public int ShikimoriId { get; set; }
    public int? MalId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? TitleRus { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleJap { get; set; }
    public string? Synonyms { get; set; }        
    public string? LicenseNameRu { get; set; }
    public string Kind { get; set; } = string.Empty;
    public string? Rating { get; set; }          
    public double? Score { get; set; }
    public string? Status { get; set; }
    public int Episodes { get; set; }
    public int EpisodesAired { get; set; }
    public int? Duration { get; set; }
    public DateOnly? AiredOn { get; set; }
    public DateOnly? ReleasedOn { get; set; }
    public string? Url { get; set; }
    public string? Season { get; set; }
    public string? PosterOriginalUrl { get; set; }
    public string? PosterMainUrl { get; set; }
    public string? Licensors { get; set; }       
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? NextEpisodeAt { get; set; }
    public bool IsCensored { get; set; }
    public string? Description { get; set; }
    public string? DescriptionHtml { get; set; }
    public string? DescriptionSource { get; set; }
    public string? PleerLink {get; set;}
}