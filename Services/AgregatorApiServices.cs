using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

public interface IAgregatorApiService
{
    public Task<KodikSearchResponse> Search(
        string? title = null,
        string? titleOrig = null,
        string? id = null,
        string? shikimoriId = null,
        string? kinopoiskId = null,
        string? imdbId = null,
        string? mdlId = null,
        string? worldartAnimationId = null,
        string? worldartLink = null,
        string? playerLink = null,
        
        // Уточнение поиска
        bool? strict = null,
        bool? fullMatch = null,
        int? limit = null,
        string? types = null,
        int? year = null,
        bool? lgbt = null,
        string? anime_kind = null,
        string? anime_status = null,
        string? rating_mpaa = null,
        int? minimal_age = null,
        double? kinopoisk_rating = null,
        double? imdb_rating = null,
        double? shikimori_rating = null,
        string? anime_studios = null,
        string? genres = null,
        string? anime_genres = null,
        int? duration = null,
        string? has_field_and = null,
        string? prioritize_translations = null,
        string? unprioritize_translations = null, 
        string? block_translations = null,
        int? season = null,
        string? countries = null,

        // Съемочная группа
        string? actors = null,
        string? directors = null,
        string? producers = null,
        string? writers = null,
        string? composers = null,
        string? editors = null,
        string? designers = null,
        string? operators = null,
        
        // Контентные уточнения
        int? translationId = null,
        string? translationType = null,
        bool? camrip = null,
        string? mydramalist_tags = null,
        
        // Дополнительные данные
        bool? withMaterialData = null,
        bool? withSeasons = null,
        bool? withEpisodes = null,
        bool? withEpisodesData = null,
        bool? withPageLinks = null
    );

    public Task<KodikSearchResponse> SearchList(
        // Базовые параметры поиска и лимиты
        int? limit = null,
        // Характеристики контента
        string? types = null,
        int? year = null,
        bool? camrip = null,
        bool? lgbt = null,
        string? animeKind = null,
        string? animeStatus = null,
        string? mydramalistTags = null,
        string? ratingMpaa = null,
        int? minimalAge = null,
        int? duration = null,
        string? countries = null,
        string? genres = null,
        string? animeGenres = null,
        string? animeStudios = null,
        // Переводы и озвучки
        int? translationId = null,
        string? translationType = null,
        string? blockTranslations = null,
        // Рейтинги
        double? kinopoiskRating = null,
        double? imdbRating = null,
        double? shikimoriRating = null,
        // Съемочная группа
        string? actors = null,
        string? directors = null,
        string? producers = null,
        string? writers = null,
        string? composers = null,
        string? editors = null,
        string? designers = null,
        string? operators = null,
        // Наличие полей, блокировки и прочее
        string? hasFieldAnd = null,
        // Сортировка
        string? sort = null,
        string? order = null,
        // ДОПОЛНИТЕЛЬНЫЕ ПАРАМЕТРЫ (Расширение ответа)
        bool? withMaterialData = null,
        bool? withSeasons = null,
        bool? withEpisodes = null,
        bool? withEpisodesData = null,
        bool? withPageLinks = null 
    );
}

public class ApiKodik : IAgregatorApiService
{
    private readonly string _apiToken;

    public ApiKodik(string apiToken)
    {
        _apiToken = apiToken;
    }

    public async Task<KodikSearchResponse> Search(
        string? title = null,
        string? titleOrig = null,
        string? id = null,
        string? shikimoriId = null,
        string? kinopoiskId = null,
        string? imdbId = null,
        string? mdlId = null,
        string? worldartAnimationId = null,
        string? worldartLink = null,
        string? playerLink = null,
        
        bool? strict = null,
        bool? fullMatch = null,
        int? limit = null,
        string? types = null,
        int? year = null,
        bool? lgbt = null,
        string? anime_kind = null,
        string? anime_status = null,
        string? rating_mpaa = null,
        int? minimal_age = null,
        double? kinopoisk_rating = null,
        double? imdb_rating = null,
        double? shikimori_rating = null,
        string? anime_studios = null,
        string? genres = null,
        string? anime_genres = null,
        int? duration = null,
        string? has_field_and = null,
        string? prioritize_translations = null,
        string? unprioritize_translations = null, 
        string? block_translations = null,
        int? season = null,
        string? countries = null,

        string? actors = null,
        string? directors = null,
        string? producers = null,
        string? writers = null,
        string? composers = null,
        string? editors = null,
        string? designers = null,
        string? operators = null,
        
        int? translationId = null,
        string? translationType = null,
        bool? camrip = null,
        string? mydramalist_tags = null,
        
        bool? withMaterialData = null,
        bool? withSeasons = null,
        bool? withEpisodes = null,
        bool? withEpisodesData = null,
        bool? withPageLinks = null)
    {
        var url = "https://kodik-api.com/search"
            .SetQueryParam("token", _apiToken);

        // Основные параметры поиска (якоря)
        if (title != null) url = url.SetQueryParam("title", title);
        if (titleOrig != null) url = url.SetQueryParam("title_orig", titleOrig);
        if (id != null) url = url.SetQueryParam("id", id);
        if (shikimoriId != null) url = url.SetQueryParam("shikimori_id", shikimoriId);
        if (kinopoiskId != null) url = url.SetQueryParam("kinopoisk_id", kinopoiskId);
        if (imdbId != null) url = url.SetQueryParam("imdb_id", imdbId);
        if (mdlId != null) url = url.SetQueryParam("mdl_id", mdlId);
        if (worldartAnimationId != null) url = url.SetQueryParam("worldart_animation_id", worldartAnimationId);
        if (worldartLink != null) url = url.SetQueryParam("worldart_link", worldartLink);
        if (playerLink != null) url = url.SetQueryParam("player_link", playerLink);

        // Уточнение поиска
        if (strict != null) url = url.SetQueryParam("strict", strict);
        if (fullMatch != null) url = url.SetQueryParam("full_match", fullMatch);
        if (limit != null) url = url.SetQueryParam("limit", limit);
        if (types != null) url = url.SetQueryParam("types", types);
        if (year != null) url = url.SetQueryParam("year", year);
        if (lgbt != null) url = url.SetQueryParam("lgbt", lgbt);
        if (anime_kind != null) url = url.SetQueryParam("anime_kind", anime_kind);
        if (anime_status != null) url = url.SetQueryParam("anime_status", anime_status);
        if (rating_mpaa != null) url = url.SetQueryParam("rating_mpaa", rating_mpaa);
        if (minimal_age != null) url = url.SetQueryParam("minimal_age", minimal_age);
        if (kinopoisk_rating != null) url = url.SetQueryParam("kinopoisk_rating", kinopoisk_rating);
        if (imdb_rating != null) url = url.SetQueryParam("imdb_rating", imdb_rating);
        if (shikimori_rating != null) url = url.SetQueryParam("shikimori_rating", shikimori_rating);
        if (anime_studios != null) url = url.SetQueryParam("anime_studios", anime_studios);
        if (genres != null) url = url.SetQueryParam("genres", genres);
        if (anime_genres != null) url = url.SetQueryParam("anime_genres", anime_genres);
        if (duration != null) url = url.SetQueryParam("duration", duration);
        if (has_field_and != null) url = url.SetQueryParam("has_field_and", has_field_and);
        if (prioritize_translations != null) url = url.SetQueryParam("prioritize_translations", prioritize_translations);
        if (unprioritize_translations != null) url = url.SetQueryParam("unprioritize_translations", unprioritize_translations);
        if (block_translations != null) url = url.SetQueryParam("block_translations", block_translations);
        if (season != null) url = url.SetQueryParam("season", season);
        if (countries != null) url = url.SetQueryParam("countries", countries);

        // Съемочная группа
        if (actors != null) url = url.SetQueryParam("actors", actors);
        if (directors != null) url = url.SetQueryParam("directors", directors);
        if (producers != null) url = url.SetQueryParam("producers", producers);
        if (writers != null) url = url.SetQueryParam("writers", writers);
        if (composers != null) url = url.SetQueryParam("composers", composers);
        if (editors != null) url = url.SetQueryParam("editors", editors);
        if (designers != null) url = url.SetQueryParam("designers", designers);
        if (operators != null) url = url.SetQueryParam("operators", operators);

        // Контентные уточнения
        if (translationId != null) url = url.SetQueryParam("translation_id", translationId);
        if (translationType != null) url = url.SetQueryParam("translation_type", translationType);
        if (camrip != null) url = url.SetQueryParam("camrip", camrip);
        if (mydramalist_tags != null) url = url.SetQueryParam("mydramalist_tags", mydramalist_tags);

        // Дополнительные данные
        if (withMaterialData != null) url = url.SetQueryParam("with_material_data", withMaterialData);
        if (withSeasons != null) url = url.SetQueryParam("with_seasons", withSeasons);
        if (withEpisodes != null) url = url.SetQueryParam("with_episodes", withEpisodes);
        if (withEpisodesData != null) url = url.SetQueryParam("with_episodes_data", withEpisodesData);
        if (withPageLinks != null) url = url.SetQueryParam("with_page_links", withPageLinks);

        return await url
            .GetAsync()                        
            .ReceiveJson<KodikSearchResponse>();
    }

    public async Task<KodikSearchResponse> SearchList(
        int? limit = null,
        string? types = null,
        int? year = null,
        bool? camrip = null,
        bool? lgbt = null,
        string? animeKind = null,
        string? animeStatus = null,
        string? mydramalistTags = null,
        string? ratingMpaa = null,
        int? minimalAge = null,
        int? duration = null,
        string? countries = null,
        string? genres = null,
        string? animeGenres = null,
        string? animeStudios = null,
        int? translationId = null,
        string? translationType = null,
        string? blockTranslations = null,
        double? kinopoiskRating = null,
        double? imdbRating = null,
        double? shikimoriRating = null,
        string? actors = null,
        string? directors = null,
        string? producers = null,
        string? writers = null,
        string? composers = null,
        string? editors = null,
        string? designers = null,
        string? operators = null,
        string? hasFieldAnd = null,
        string? sort = null,
        string? order = null,
        bool? withMaterialData = null,
        bool? withSeasons = null,
        bool? withEpisodes = null,
        bool? withEpisodesData = null,
        bool? withPageLinks = null)
    {
        var url = "https://kodik-api.com/list"
            .SetQueryParam("token", _apiToken);

        // Базовые параметры поиска и лимиты
        if (limit != null) url = url.SetQueryParam("limit", limit);

        // Характеристики контента
        if (types != null) url = url.SetQueryParam("types", types);
        if (year != null) url = url.SetQueryParam("year", year);
        if (camrip != null) url = url.SetQueryParam("camrip", camrip);
        if (lgbt != null) url = url.SetQueryParam("lgbt", lgbt);
        if (animeKind != null) url = url.SetQueryParam("anime_kind", animeKind);
        if (animeStatus != null) url = url.SetQueryParam("anime_status", animeStatus);
        if (mydramalistTags != null) url = url.SetQueryParam("mydramalist_tags", mydramalistTags);
        if (ratingMpaa != null) url = url.SetQueryParam("rating_mpaa", ratingMpaa);
        if (minimalAge != null) url = url.SetQueryParam("minimal_age", minimalAge);
        if (duration != null) url = url.SetQueryParam("duration", duration);
        if (countries != null) url = url.SetQueryParam("countries", countries);
        if (genres != null) url = url.SetQueryParam("genres", genres);
        if (animeGenres != null) url = url.SetQueryParam("anime_genres", animeGenres);
        if (animeStudios != null) url = url.SetQueryParam("anime_studios", animeStudios);

        // Переводы и озвучки
        if (translationId != null) url = url.SetQueryParam("translation_id", translationId);
        if (translationType != null) url = url.SetQueryParam("translation_type", translationType);
        if (blockTranslations != null) url = url.SetQueryParam("block_translations", blockTranslations);

        // Рейтинги
        if (kinopoiskRating != null) url = url.SetQueryParam("kinopoisk_rating", kinopoiskRating);
        if (imdbRating != null) url = url.SetQueryParam("imdb_rating", imdbRating);
        if (shikimoriRating != null) url = url.SetQueryParam("shikimori_rating", shikimoriRating);

        // Съемочная группа
        if (actors != null) url = url.SetQueryParam("actors", actors);
        if (directors != null) url = url.SetQueryParam("directors", directors);
        if (producers != null) url = url.SetQueryParam("producers", producers);
        if (writers != null) url = url.SetQueryParam("writers", writers);
        if (composers != null) url = url.SetQueryParam("composers", composers);
        if (editors != null) url = url.SetQueryParam("editors", editors);
        if (designers != null) url = url.SetQueryParam("designers", designers);
        if (operators != null) url = url.SetQueryParam("operators", operators);

        // Наличие полей, блокировки и прочее
        if (hasFieldAnd != null) url = url.SetQueryParam("has_field_and", hasFieldAnd);

        // Сортировка
        if (sort != null) url = url.SetQueryParam("sort", sort);
        if (order != null) url = url.SetQueryParam("order", order);

        // Дополнительные параметры
        if (withMaterialData != null) url = url.SetQueryParam("with_material_data", withMaterialData);
        if (withSeasons != null) url = url.SetQueryParam("with_seasons", withSeasons);
        if (withEpisodes != null) url = url.SetQueryParam("with_episodes", withEpisodes);
        if (withEpisodesData != null) url = url.SetQueryParam("with_episodes_data", withEpisodesData);
        if (withPageLinks != null) url = url.SetQueryParam("with_page_links", withPageLinks);

        return await url
            .GetAsync()                        
            .ReceiveJson<KodikSearchResponse>();
    }
};
