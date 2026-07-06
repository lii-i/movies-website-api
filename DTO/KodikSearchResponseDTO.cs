using System.Text.Json.Serialization;
using System.Collections.Generic;

public class KodikSearchResponseDTO
{
    
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("prev_page")]
    public string? PrevPage { get; set; }

    [JsonPropertyName("next_page")]
    public string? NextPage { get; set; }

    [JsonPropertyName("results")]
    public List<KodikItem> Results { get; set; } = new();
}

public class KodikItem
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("title_orig")]
    public string TitleOrig { get; set; } = string.Empty;

    [JsonPropertyName("other_title")]
    public string OtherTitle { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("screenshots")]
    public List<string> Screenshots { get; set; } = new();

    [JsonPropertyName("shikimori_id")]
    public string? ShikimoriId { get; set; }

    [JsonPropertyName("kinopoisk_id")]
    public string? KinopoiskId { get; set; }

    [JsonPropertyName("imdb_id")]
    public string? ImdbId { get; set; }

    [JsonPropertyName("worldart_link")]
    public string? WorldartLink { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; } = string.Empty;

    [JsonPropertyName("camrip")]
    public bool Camrip { get; set; }

    [JsonPropertyName("lgbt")]
    public bool Lgbt { get; set; }

    [JsonPropertyName("blocked_countries")]
    public List<string> BlockedCountries { get; set; } = new();

    [JsonPropertyName("blocked_seasons")]
    public Dictionary<string, object>? BlockedSeasons { get; set; } 

    // Только для сериалов
    [JsonPropertyName("last_season")]
    public int? LastSeason { get; set; }

    [JsonPropertyName("last_episode")]
    public int? LastEpisode { get; set; }

    [JsonPropertyName("episodes_count")]
    public int? EpisodesCount { get; set; }

    [JsonPropertyName("anime_title")]
    public string? AnimeTitle { get; set; }

    [JsonPropertyName("title_en")]
    public string? TitleEn { get; set; }

    [JsonPropertyName("other_titles")]
    public List<string> OtherTitles { get; set; } = new();

    [JsonPropertyName("other_titles_en")]
    public List<string> OtherTitlesEn { get; set; } = new();

    [JsonPropertyName("other_titles_jp")]
    public List<string> OtherTitlesJp { get; set; } = new();

    [JsonPropertyName("anime_kind")]
    public string? AnimeKind { get; set; }

    [JsonPropertyName("all_status")]
    public string? AllStatus { get; set; }

    [JsonPropertyName("anime_status")]
    public string? AnimeStatus { get; set; }

    [JsonPropertyName("tagline")]
    public string? Tagline { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("anime_description")]
    public string? AnimeDescription { get; set; }

    [JsonPropertyName("poster_url")]
    public string? PosterUrl { get; set; }

    [JsonPropertyName("anime_poster_url")]
    public string? AnimePosterUrl { get; set; }

    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("countries")]
    public List<string> Countries { get; set; } = new();

    [JsonPropertyName("all_genres")]
    public List<string> AllGenres { get; set; } = new();

    [JsonPropertyName("genres")]
    public List<string> Genres { get; set; } = new();

    [JsonPropertyName("anime_genres")]
    public List<string> AnimeGenres { get; set; } = new();

    [JsonPropertyName("anime_studios")]
    public List<string> AnimeStudios { get; set; } = new();

    [JsonPropertyName("kinopoisk_rating")]
    public double? KinopoiskRating { get; set; }

    [JsonPropertyName("kinopoisk_votes")]
    public int? KinopoiskVotes { get; set; }

    [JsonPropertyName("imdb_rating")]
    public double? ImdbRating { get; set; }

    [JsonPropertyName("imdb_votes")]
    public int? ImdbVotes { get; set; }

    [JsonPropertyName("shikimori_rating")]
    public double? ShikimoriRating { get; set; }

    [JsonPropertyName("shikimori_votes")]
    public int? ShikimoriVotes { get; set; }

    [JsonPropertyName("premiere_ru")]
    public string? PremiereRu { get; set; }

    [JsonPropertyName("premiere_world")]
    public string? PremiereWorld { get; set; }

    [JsonPropertyName("aired_at")]
    public string? AiredAt { get; set; }

    [JsonPropertyName("released_at")]
    public string? ReleasedAt { get; set; }

    [JsonPropertyName("rating_mpaa")]
    public string? RatingMpaa { get; set; }

    [JsonPropertyName("minimal_age")]
    public int? MinimalAge { get; set; }
    
    [JsonPropertyName("translation")]
    public KodikTranslation? Translation  {get; set;}

    [JsonPropertyName("episodes_total")]
    public int? EpisodesTotal { get; set; }

    [JsonPropertyName("episodes_aired")]
    public int? EpisodesAired { get; set; }

    [JsonPropertyName("actors")]
    public List<string> Actors { get; set; } = new();

    [JsonPropertyName("directors")]
    public List<string> Directors { get; set; } = new();

    [JsonPropertyName("producers")]
    public List<string> Producers { get; set; } = new();

    [JsonPropertyName("writers")]
    public List<string> Writers { get; set; } = new();

    [JsonPropertyName("composers")]
    public List<string> Composers { get; set; } = new();

    [JsonPropertyName("editors")]
    public List<string> Editors { get; set; } = new();

    [JsonPropertyName("designers")]
    public List<string> Designers { get; set; } = new();

    [JsonPropertyName("operators")]
    public List<string> Operators { get; set; } = new();
}

public class KodikTranslation
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}