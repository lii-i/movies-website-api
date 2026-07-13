using Microsoft.EntityFrameworkCore;

public interface IRepository {
    public Task InsertAnime(AnimeItemsEntity anime);
    public Task UpdateAnimeItem(AnimeItemsEntity anime);
    public Task UpdateAnimeItem(AnimeItemsEntity source, AnimeItemsEntity newdata);
}

public class Repository : IRepository {
    private CinemaDbContext _db;

    public Repository(CinemaDbContext db){
        _db = db;
    }

    public async Task InsertAnime(AnimeItemsEntity anime){
        AnimeItemsEntity? item = await _db.AnimeItems.FirstOrDefaultAsync(a => a.ShikimoriId == anime.ShikimoriId);
        if(item == null) {
            _db.AnimeItems.Add(anime);
        }else{
            return;
        }
        await _db.SaveChangesAsync();
    }

    public async Task InsertOrUpdateAnime(AnimeItemsEntity anime){
        AnimeItemsEntity? item = await _db.AnimeItems.FirstOrDefaultAsync(a => a.ShikimoriId == anime.ShikimoriId);
        if(item == null) {
            _db.AnimeItems.Add(anime);
        }else{
            await UpdateAnimeItem(item, anime);
        }
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAnimeItem(AnimeItemsEntity anime){
        AnimeItemsEntity? item = await _db.AnimeItems.FirstOrDefaultAsync(a => a.ShikimoriId == anime.ShikimoriId);
        if(item == null) {
            return;
        }
        item.MalId             = anime.MalId;
        item.Title             = anime.Title;
        item.TitleRus          = anime.TitleRus;
        item.TitleEn           = anime.TitleEn;
        item.TitleJap          = anime.TitleJap;
        item.Synonyms          = anime.Synonyms;
        item.LicenseNameRu     = anime.LicenseNameRu;
        item.Kind              = anime.Kind;
        item.Rating            = anime.Rating;
        item.Score             = anime.Score;
        item.Status            = anime.Status;
        item.Episodes          = anime.Episodes;
        item.EpisodesAired     = anime.EpisodesAired;
        item.Duration          = anime.Duration;
        item.AiredOn           = anime.AiredOn;
        item.ReleasedOn        = anime.ReleasedOn;
        item.Url               = anime.Url;
        item.Season            = anime.Season;
        item.PosterOriginalUrl = anime.PosterOriginalUrl;
        item.PosterMainUrl     = anime.PosterMainUrl;
        item.Licensors         = anime.Licensors;
        item.CreatedAt         = anime.CreatedAt;
        item.UpdatedAt         = anime.UpdatedAt;
        item.NextEpisodeAt     = anime.NextEpisodeAt;
        item.IsCensored        = anime.IsCensored;
        item.Description       = anime.Description;
        item.DescriptionHtml   = anime.DescriptionHtml;
        item.DescriptionSource = anime.DescriptionSource;
        item.PleerLink         = anime.PleerLink;
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAnimeItem(AnimeItemsEntity source, AnimeItemsEntity newdata){
        source.MalId             = newdata.MalId;
        source.Title             = newdata.Title;
        source.TitleRus          = newdata.TitleRus;
        source.TitleEn           = newdata.TitleEn;
        source.TitleJap          = newdata.TitleJap;
        source.Synonyms          = newdata.Synonyms;
        source.LicenseNameRu     = newdata.LicenseNameRu;
        source.Kind              = newdata.Kind;
        source.Rating            = newdata.Rating;
        source.Score             = newdata.Score;
        source.Status            = newdata.Status;
        source.Episodes          = newdata.Episodes;
        source.EpisodesAired     = newdata.EpisodesAired;
        source.Duration          = newdata.Duration;
        source.AiredOn           = newdata.AiredOn;
        source.ReleasedOn        = newdata.ReleasedOn;
        source.Url               = newdata.Url;
        source.Season            = newdata.Season;
        source.PosterOriginalUrl = newdata.PosterOriginalUrl;
        source.PosterMainUrl     = newdata.PosterMainUrl;
        source.Licensors         = newdata.Licensors;
        source.CreatedAt         = newdata.CreatedAt;
        source.UpdatedAt         = newdata.UpdatedAt;
        source.NextEpisodeAt     = newdata.NextEpisodeAt;
        source.IsCensored        = newdata.IsCensored;
        source.Description       = newdata.Description;
        source.DescriptionHtml   = newdata.DescriptionHtml;
        source.DescriptionSource = newdata.DescriptionSource;
        source.PleerLink         = newdata.PleerLink;
        await _db.SaveChangesAsync();
    }
}