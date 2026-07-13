using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

public class ShikimoriSearchResponseDTO 
{
    [JsonPropertyName("animes")]
    public List<GraphQLAnimeDTO> Animes { get; set; } = new();
}

public class GraphQLAnimeDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } 

    [JsonPropertyName("malId")]
    public string? MalId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("russian")]
    public string? Russian { get; set; }

    [JsonPropertyName("licenseNameRu")]
    public string? LicenseNameRu { get; set; }

    [JsonPropertyName("english")]
    public string? English { get; set; }

    [JsonPropertyName("japanese")]
    public string? Japanese { get; set; }

    [JsonPropertyName("synonyms")]
    public List<string> Synonyms { get; set; } = new();

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("rating")]
    public string? Rating { get; set; }

    [JsonPropertyName("page")]
    public int? Page { get; set; }

    [JsonPropertyName("score")]
    public double? Score { get; set; } 

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("episodes")]
    public int? Episodes { get; set; }

    [JsonPropertyName("episodesAired")]
    public int? EpisodesAired { get; set; }

    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("airedOn")]
    public DateInfoDTO? AiredOn { get; set; } 

    [JsonPropertyName("releasedOn")]
    public DateInfoDTO? ReleasedOn { get; set; } 

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("season")]
    public string? Season { get; set; }

    [JsonPropertyName("poster")]
    public AnimePosterDTO? Poster { get; set; } 

    [JsonPropertyName("fansubbers")]
    public List<string> Fansubbers { get; set; } = new();

    [JsonPropertyName("fandubbers")]
    public List<string> Fandubbers { get; set; } = new();

    [JsonPropertyName("licensors")]
    public List<string> Licensors { get; set; } = new();

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("nextEpisodeAt")]
    public DateTime? NextEpisodeAt { get; set; }

    [JsonPropertyName("isCensored")]
    public bool IsCensored { get; set; }

    [JsonPropertyName("genres")]
    public List<GraphGenreDTO> Genres { get; set; } = new();

    [JsonPropertyName("studios")]
    public List<GraphStudioDTO> Studios { get; set; } = new();

    [JsonPropertyName("externalLinks")]
    public List<ExternalLinkDTO> ExternalLinks { get; set; } = new();

    [JsonPropertyName("personRoles")]
    public List<PersonRoleDTO> PersonRoles { get; set; } = new();

    [JsonPropertyName("characterRoles")]
    public List<CharacterRoleDTO> CharacterRoles { get; set; } = new();

    [JsonPropertyName("related")]
    public List<RelatedDTO> Related { get; set; } = new();

    [JsonPropertyName("videos")]
    public List<GraphVideoDTO> Videos { get; set; } = new();

    [JsonPropertyName("screenshots")]
    public List<GraphScreenshotDTO> Screenshots { get; set; } = new();

    [JsonPropertyName("scoresStats")]
    public List<GraphScoreStatDTO> ScoresStats { get; set; } = new();

    [JsonPropertyName("statusesStats")]
    public List<GraphStatusStatDTO> StatusesStats { get; set; } = new();

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("descriptionHtml")]
    public string? DescriptionHtml { get; set; }

    [JsonPropertyName("descriptionSource")]
    public string? DescriptionSource { get; set; }

    public string? PleerLink { get; set; }
}

public class DateInfoDTO
{
    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("month")]
    public int? Month { get; set; }

    [JsonPropertyName("day")]
    public int? Day { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }
}

public class AnimePosterDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("originalUrl")]
    public string? OriginalUrl { get; set; }

    [JsonPropertyName("mainUrl")]
    public string? MainUrl { get; set; }
}

public class PersonPosterDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("mainUrl")]
    public string? MainUrl { get; set; }

    [JsonPropertyName("mainAltUrl")]
    public string? MainAltUrl { get; set; }
}

public class GraphGenreDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("russian")]
    public string? Russian { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }
}

public class GraphStudioDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
}

public class ExternalLinkDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
}

public class PersonRoleDTO
{
    [JsonPropertyName("rolesEn")]
    public List<string> RolesEn { get; set; } = new();

    [JsonPropertyName("rolesRu")]
    public List<string> RolesRu { get; set; } = new();

    [JsonPropertyName("person")]
    public PersonDTO? Person { get; set; }
}

public class PersonDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("russian")]
    public string? Russian { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("poster")]
    public PersonPosterDTO? Poster { get; set; }
}

public class CharacterRoleDTO
{
    [JsonPropertyName("rolesEn")]
    public List<string> RolesEn { get; set; } = new();

    [JsonPropertyName("rolesRu")]
    public List<string> RolesRu { get; set; } = new();

    [JsonPropertyName("character")]
    public CharacterDTO? Character { get; set; }
}

public class CharacterDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("russian")]
    public string? Russian { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("japanese")]
    public string? Japanese { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("descriptionHtml")]
    public string? DescriptionHtml { get; set; }

    [JsonPropertyName("descriptionSource")]
    public string? DescriptionSource { get; set; }

    [JsonPropertyName("updatedAt")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("poster")]
    public PersonPosterDTO? Poster { get; set; } 
    
    public List<SeyuDTO> Seyu { get; set; } = new();
}

public class SeyuDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("russian")]
    public string? Russian { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("poster")]
    public PersonPosterDTO? Poster { get; set; }
}

public class RelatedDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("anime")]
    public RelatedMediaDTO? Anime { get; set; }

    [JsonPropertyName("manga")]
    public RelatedMediaDTO? Manga { get; set; }

    [JsonPropertyName("relationKind")]
    public string? RelationKind { get; set; }

    [JsonPropertyName("relationText")]
    public string? RelationText { get; set; }
}

public class RelatedMediaDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("russian")]
    public string? Russian { get; set; }

    [JsonPropertyName("english")]
    public string? English { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
    
    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("poster")]
    public AnimePosterDTO? Poster { get; set; } 
}

public class GraphVideoDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("playerUrl")]
    public string? PlayerUrl { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }
}

public class GraphScreenshotDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("originalUrl")]
    public string? OriginalUrl { get; set; }

    [JsonPropertyName("x166Url")]
    public string? X166Url { get; set; }

    [JsonPropertyName("x332Url")]
    public string? X332Url { get; set; }
}

public class GraphScoreStatDTO
{
    [JsonPropertyName("score")]
    public int Score { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class GraphStatusStatDTO
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class GraphQLResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("errors")]
    public List<GraphQLError>? Errors { get; set; }
}

public class GraphQLError
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}