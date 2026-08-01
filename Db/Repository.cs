using Microsoft.EntityFrameworkCore;

public interface IRepository
{
    Task AddOrUpdateAnimeAsync(AnimeResponseDTO anime);
    Task<AnimeEntity?> GetAnimeByIdAsync(int id);
    Task<List<AnimeEntity>> GetAnimeByFiltersAsync(SearchRequestParamDTO param);
}

public class Repository : IRepository
{
    private readonly CinemaDbContext _db;

    private const int DurationShortMax  = 10;
    private const int DurationMediumMax = 30;

    public Repository(CinemaDbContext db)
    {
        _db = db;
    }

    public async Task AddOrUpdateAnimeAsync(AnimeResponseDTO anime)
    {
        AnimeEntity? existing = await _db.Animes.FirstOrDefaultAsync(a => a.Id == anime.Id);

        if (existing == null)
        {
            _db.Animes.Add(MapToEntity(anime));
        }
        else
        {
            UpdateEntity(existing, anime);
        }

        await _db.SaveChangesAsync();
    }

    public async Task<AnimeEntity?> GetAnimeByIdAsync(int id)
    {
        return await _db.Animes.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<AnimeEntity>> GetAnimeByFiltersAsync(SearchRequestParamDTO param)
    {
        IQueryable<AnimeEntity> query = _db.Animes;

        if (!string.IsNullOrEmpty(param.Title))
            query = query.Where(a =>
                a.Title.Contains(param.Title) ||
                (a.OriginalTitle != null && a.OriginalTitle.Contains(param.Title)));

        if (!string.IsNullOrEmpty(param.Rating))
            query = query.Where(a => a.AgeRating == param.Rating);

        if (!string.IsNullOrEmpty(param.Kind))
            query = query.Where(a => a.Kind == param.Kind);

        if (!string.IsNullOrEmpty(param.Status))
            query = query.Where(a => a.Status == param.Status);

        if (!string.IsNullOrEmpty(param.Season))
            query = query.Where(a => a.Season == param.Season);

        if (param.Score.HasValue && param.Score >= 1)
            query = query.Where(a => a.Rating >= param.Score.Value);

        if (!string.IsNullOrEmpty(param.Duration))
        {
            var dur = param.Duration.Trim().ToLowerInvariant();
            if (dur == "s")
                query = query.Where(a => a.Duration < DurationShortMax);
            else if (dur == "d")
                query = query.Where(a => a.Duration >= DurationShortMax && a.Duration <= DurationMediumMax);
            else if (dur == "f")
                query = query.Where(a => a.Duration > DurationMediumMax);
        }

        if (!string.IsNullOrEmpty(param.Genre))
        {
            var genres = param.Genre
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(g => g.Trim())
                .ToList();
            foreach (var g in genres)
                query = query.Where(a => a.Genres.Contains(g));
        }

        if (!string.IsNullOrEmpty(param.Studio))
        {
            var studios = param.Studio
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();
            foreach (var s in studios)
                query = query.Where(a => a.Studios.Contains(s));
        }

        if(param.Censored != null){
            query = query.Where(a => a.Censored == param.Censored);
        }

        if (!string.IsNullOrEmpty(param.Ids))
        {
            var ids = param.Ids
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.TryParse(i.Trim(), out var n) ? n : -1)
                .Where(n => n > 0)
                .ToList();
            if (ids.Count > 0)
                query = query.Where(a => ids.Contains(a.Id));
        }

        if (!string.IsNullOrEmpty(param.ExcludeIds))
        {
            var excludeIds = param.ExcludeIds
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.TryParse(i.Trim(), out var n) ? n : -1)
                .Where(n => n > 0)
                .ToList();
            if (excludeIds.Count > 0)
                query = query.Where(a => !excludeIds.Contains(a.Id));
        }

        query = param.Order?.Trim() switch
        {
            "id"       => query.OrderBy(a => a.Id),
            "ranked"   => query.OrderByDescending(a => a.Rating),
            "kind"     => query.OrderBy(a => a.Kind),
            "name"     => query.OrderBy(a => a.Title),
            "aired_on" => query.OrderByDescending(a => a.AiredOn),
            "episodes" => query.OrderByDescending(a => a.Episodes),
            "status"   => query.OrderBy(a => a.Status),
            _          => query.OrderByDescending(a => a.Rating)
        };

        if (param.Limit.HasValue && param.Limit > 0){
            if(param.Page != null){
                query = query.Skip((param.Page.Value * param.Limit.Value) - param.Limit.Value).Take(param.Limit.Value);
            }else{
                query = query.Take(param.Limit.Value);
            }
        }

        return await query.ToListAsync();
    }

    private static AnimeEntity MapToEntity(AnimeResponseDTO dto) => new()
    {
        Id              = dto.Id,
        MalId           = dto.MalId,
        Title           = dto.Title,
        OriginalTitle   = dto.OriginalTitle,
        TitleEn         = dto.TitleEn,
        TitleJap        = dto.TitleJap,
        Synonyms        = dto.Synonyms,
        Poster          = dto.Poster,
        PosterOriginal  = dto.PosterOriginal,
        Backdrop        = dto.Backdrop,
        Rating          = dto.Rating,
        AgeRating       = dto.AgeRating,
        Kind            = dto.Kind,
        Status          = dto.Status,
        Season          = dto.Season,
        Year            = dto.Year,
        AiredOn         = dto.AiredOn,
        ReleasedOn      = dto.ReleasedOn,
        Episodes        = dto.Episodes,
        EpisodesAired   = dto.EpisodesAired,
        Duration        = dto.Duration,
        Genres          = dto.Genres,
        Director        = dto.Director,
        Studios         = dto.Studios,
        Cast            = dto.Cast,
        Description     = dto.Description,
        DescriptionHtml = dto.DescriptionHtml,
        Censored        = dto.Censored,
        EmbedUrl        = dto.EmbedUrl,
        Screenshots     = dto.Screenshots,
        Related         = dto.Related
    };

    private static void UpdateEntity(AnimeEntity entity, AnimeResponseDTO dto)
    {
        entity.MalId           = dto.MalId;
        entity.Title           = dto.Title;
        entity.OriginalTitle   = dto.OriginalTitle;
        entity.TitleEn         = dto.TitleEn;
        entity.TitleJap        = dto.TitleJap;
        entity.Synonyms        = dto.Synonyms;
        entity.Poster          = dto.Poster;
        entity.PosterOriginal  = dto.PosterOriginal;
        entity.Backdrop        = dto.Backdrop;
        entity.Rating          = dto.Rating;
        entity.AgeRating       = dto.AgeRating;
        entity.Kind            = dto.Kind;
        entity.Status          = dto.Status;
        entity.Season          = dto.Season;
        entity.Year            = dto.Year;
        entity.AiredOn         = dto.AiredOn;
        entity.ReleasedOn      = dto.ReleasedOn;
        entity.Episodes        = dto.Episodes;
        entity.EpisodesAired   = dto.EpisodesAired;
        entity.Duration        = dto.Duration;
        entity.Genres          = dto.Genres;
        entity.Director        = dto.Director;
        entity.Studios         = dto.Studios;
        entity.Cast            = dto.Cast;
        entity.Description     = dto.Description;
        entity.DescriptionHtml = dto.DescriptionHtml;
        entity.Censored        = dto.Censored;
        entity.EmbedUrl        = dto.EmbedUrl;
        entity.Screenshots     = dto.Screenshots;
        entity.Related         = dto.Related;
    }
}