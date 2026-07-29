using Microsoft.EntityFrameworkCore;

public interface IRepository
{
    Task AddOrUpdateAnimeAsync(AnimeResponseDTO anime);
    Task<AnimeEntity?> GetAnimeByIdAsync(int id);
}

public class Repository : IRepository
{
    private readonly CinemaDbContext _db;

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
        EmbedUrl        = dto.EmbedUrl,
        Screenshots     = dto.Screenshots,
        Related         = dto.Related  // RelatedAnimeDTO == тип хранения, маппинг не нужен
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
        entity.EmbedUrl        = dto.EmbedUrl;
        entity.Screenshots     = dto.Screenshots;
        entity.Related         = dto.Related;  // RelatedAnimeDTO == тип хранения, маппинг не нужен
    }
}