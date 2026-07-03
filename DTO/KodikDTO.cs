using System.Text.Json.Serialization;

public class KodikSearchResponse
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

    [JsonPropertyName("link")]
    public string Link { get; set; } = string.Empty;

    [JsonPropertyName("additional_data")]
    public KodikAdditionalData? AdditionalData { get; set; }

    [JsonPropertyName("material_data")]
    public KodikMaterialData? MaterialData { get; set; }
}

public class KodikAdditionalData
{
    [JsonPropertyName("camrip")]
    public bool Camrip { get; set; }

    [JsonPropertyName("lgbt")]
    public bool Lgbt { get; set; }

    [JsonPropertyName("blocked_countries")]
    public List<string> BlockedCountries { get; set; } = new();

    // Только для сериалов
    [JsonPropertyName("last_season")]
    public int? LastSeason { get; set; }

    [JsonPropertyName("last_episode")]
    public int? LastEpisode { get; set; }

    [JsonPropertyName("episodes_count")]
    public int? EpisodesCount { get; set; }
}

public class KodikMaterialData
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("anime_title")]
    public string? AnimeTitle { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("anime_description")]
    public string? AnimeDescription { get; set; }

    [JsonPropertyName("poster_url")]
    public string? PosterUrl { get; set; }

    [JsonPropertyName("anime_poster_url")]
    public string? AnimePosterUrl { get; set; }

    [JsonPropertyName("screenshots")]
    public List<string> Screenshots { get; set; } = new();

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

    [JsonPropertyName("minimal_age")]
    public int? MinimalAge { get; set; }

    [JsonPropertyName("episodes_total")]
    public int? EpisodesTotal { get; set; }

    [JsonPropertyName("actors")]
    public List<string> Actors { get; set; } = new();

    [JsonPropertyName("directors")]
    public List<string> Directors { get; set; } = new();

    [JsonPropertyName("anime_kind")]
    public string? AnimeKind { get; set; }

    [JsonPropertyName("premiere_world")]
    public string? PremiereWorld { get; set; }

    [JsonPropertyName("tagline")]
    public string? Tagline { get; set; }
}
