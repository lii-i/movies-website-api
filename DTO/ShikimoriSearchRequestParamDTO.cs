using System.Text.Json.Serialization;

public class ShikimoriSearchRequestParamDTO
{
    /// Название аниме
    [JsonPropertyName("search")]
    public string? Title { get; set; }

    /// Максимальное количество выдач (макс: 50)
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// Возрастной рейтинг: 
    /// "g" (Все возрасты), "pg" (Дети), "pg_13" (Подростки от 13 лет), 
    /// "r" (17+), "r_plus" (Умеренная нагота), "rx" (Hentai)
    [JsonPropertyName("rating")]
    public string? Rating { get; set; }

    /// Номер страницы (значение между 1 и 100000)
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// Сортировка: "id", "ranked", "kind", "popularity", "name", 
    /// "aired_on", "episodes", "status", "random"
    [JsonPropertyName("order")]
    public string? Order { get; set; }

    /// Тип аниме: "tv", "movie", "ova", "ona", "special", 
    /// "tv_special", "music", "pv", "cm", "tv_13", "tv_24", "tv_48"
    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    /// Статус выхода: "anons", "ongoing", "released"
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// Сезон аниме. Примеры: "summer_2017", "2016", "2014_2016", "199x"
    [JsonPropertyName("season")]
    public string? Season { get; set; }

    /// Минимальный рейтинг
    [JsonPropertyName("score")]
    public int? Score { get; set; }

    /// Продолжительность: 
    /// "S" (< 5 минут), "D" (< 30 минут), "F" (> 30 минут)
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    /// Жанры (указываются id жанров через запятую)
    [JsonPropertyName("genre")]
    public string? Genre { get; set; }

    /// Жанры v2 (указываются id v2 жанров через запятую)
    [JsonPropertyName("genre_v2")]
    public string? GenreV2 { get; set; }

    /// Студии (указываются id студий через запятую)
    [JsonPropertyName("studio")]
    public string? Studio { get; set; }

    /// Франшизы (указываются id франшиз через запятую)
    [JsonPropertyName("franchize")]
    public string? Franchize { get; set; }

    /// Скрывать 18+ (false - чтобы разрешить поиск hentai, yaoi, yuri)
    [JsonPropertyName("censored")]
    public bool? Censored { get; set; }

    /// id аниме (указываются через запятую)
    [JsonPropertyName("ids")]
    public string? Ids { get; set; }

    /// id аниме которые не будут включены в поиск (указываются через запятую)
    [JsonPropertyName("exclude_ids")]
    public string? ExcludeIds { get; set; }
}