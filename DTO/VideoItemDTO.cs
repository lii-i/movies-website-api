public class VideoItemsDTO{
    public string? PrevPage { get; set; }
    public string? NextPage { get; set; }
    public List<VideoItemDTO> videoItems {get; set;} 
}

public class VideoItemDTO {
    public string Title { get; set; } = string.Empty;
    public string TitleOrig { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? TitleEn { get; set; }
    public int Year { get; set; }
    public string Link { get; set; } = string.Empty;
    public int? LastSeason { get; set; }
    public int? LastEpisode { get; set; }
    public int? EpisodesCount { get; set; }
    public string? AllStatus { get; set; }
    public string? Description { get; set; }
    public string? PosterUrl { get; set; }
    public string? AnimePosterUrl { get; set; }
    public int? Duration { get; set; }
    public double? KinopoiskRating { get; set; }
    public int? KinopoiskVotes { get; set; }
    public double? ImdbRating { get; set; }
    public int? ImdbVotes { get; set; }
    public double? ShikimoriRating { get; set; }
    public int? ShikimoriVotes { get; set; }
    public KodikTranslation? Translation  {get; set;}
    public string? PremiereRu { get; set; }
    public string? PremiereWorld { get; set; }
    public string? AiredAt { get; set; }
    public string? ReleasedAt { get; set; }
    public string? RatingMpaa { get; set; }
    public int? MinimalAge { get; set; }
    public int? EpisodesTotal { get; set; }
    public int? EpisodesAired { get; set; }
}

