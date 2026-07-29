public class AnimeEntity
{
    public int Id { get; set; }
    public int? MalId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleJap { get; set; }
    public List<string> Synonyms { get; set; } = new();

    public string? Poster { get; set; }
    public string? PosterOriginal { get; set; }
    public string? Backdrop { get; set; }

    public double? Rating { get; set; }
    public string? AgeRating { get; set; }

    public string? Kind { get; set; }
    public string? Status { get; set; }
    public string? Season { get; set; }

    public int? Year { get; set; }
    public DateOnly? AiredOn { get; set; }
    public DateOnly? ReleasedOn { get; set; }

    public int? Episodes { get; set; }
    public int? EpisodesAired { get; set; }
    public int? Duration { get; set; }

    public List<string> Genres { get; set; } = new();
    public string? Director { get; set; }
    public List<string> Studios { get; set; } = new();
    public List<string> Cast { get; set; } = new();

    public string? Description { get; set; }
    public string? DescriptionHtml { get; set; }

    public string? EmbedUrl { get; set; }

    public List<string> Screenshots { get; set; } = new();
    public List<RelatedAnimeDTO> Related { get; set; } = new();
}

