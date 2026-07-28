using System.Text.Json.Serialization;

public class SearchRequestParamDTO
{
    public string? Title { get; set; }
    public int? Limit { get; set; }
    public string? Rating { get; set; }
    public int? Page { get; set; }
    public string? Order { get; set; }
    public string? Kind { get; set; }
    public string? Status { get; set; }
    public string? Season { get; set; }
    public int? Score { get; set; }
    public string? Duration { get; set; }
    public string? Genre { get; set; }
    public string? GenreV2 { get; set; }
    public string? Studio { get; set; }
    public string? Franchize { get; set; }
    public bool? Censored { get; set; }
    public string? Ids { get; set; }
    public string? ExcludeIds { get; set; }
}