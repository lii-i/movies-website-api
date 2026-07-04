using Flurl;
using Flurl.Http;

interface IAgregatorApiService{
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
    
    // Контентные уточнения (помогают найти конкретную версию)
    int? translationId = null,
    string? translationType = null,
    int? season = null,
    
    // Дополнительные данные (для получения информации сразу)
    bool? withMaterialData = null,
    bool? withSeasons = null,
    bool? withEpisodes = null,
    bool? withEpisodesData = null,
    bool? withPageLinks = null
);
    public Task<KodikSearchResponse> SearchList(
         // Базовые параметры поиска и лимиты
        int? limit = null,
        string? title = null,
        string? titleOrig = null,
        bool? strict = null,
        bool? fullMatch = null,
        // Идентификаторы
        string? shikimoriId = null,
        string? kinopoiskId = null,
        string? imdbId = null,
        string? id = null, // Внутренний ID Kodik
        string? mdlId = null,
        string? worldartAnimationId = null,
        string? worldartCinemaId = null,
        string? worldartLink = null,
        string? playerLink = null,
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
        string? prioritizeTranslations = null,
        string? unprioritizeTranslations = null,
        string? blockTranslations = null,
        string? prioritizeTranslationType = null,
        // Рейтинги
        float? kinopoiskRating = null,
        float? imdbRating = null,
        float? shikimoriRating = null,
        // Сезоны и серии
        int? season = null,
        int? episode = null,
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
        string? hasField = null,
        string? hasFields = null,
        string? hasFieldAnd = null,
        string? notBlockedIn = null,
        bool? notBlockedForMe = null, // Обычно передается как флаг (true/false)
        string? licensedBy = null,
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

};

public class ApiKodik: IAgregatorApiService{
    private string _apiToken;

    public ApiKodik (string apiToken){
        _apiToken = apiToken;
    }

    public async Task<KodikSearchResponse> Search(
    // Основные параметры поиска (якоря)
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
    
    // Контентные уточнения (помогают найти конкретную версию)
    int? translationId = null,
    string? translationType = null,
    int? season = null,
    
    // Дополнительные данные (для получения информации сразу)
    bool? withMaterialData = null,
    bool? withSeasons = null,
    bool? withEpisodes = null,
    bool? withEpisodesData = null,
    bool? withPageLinks = null
    ){

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

        // Контентные уточнения
        if (translationId != null) url = url.SetQueryParam("translation_id", translationId);
        if (translationType != null) url = url.SetQueryParam("translation_type", translationType);
        if (season != null) url = url.SetQueryParam("season", season);

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
        // Базовые параметры поиска и лимиты
        int? limit = null,
        string? title = null,
        string? titleOrig = null,
        bool? strict = null,
        bool? fullMatch = null,
        // Идентификаторы
        string? shikimoriId = null,
        string? kinopoiskId = null,
        string? imdbId = null,
        string? id = null, // Внутренний ID Kodik
        string? mdlId = null,
        string? worldartAnimationId = null,
        string? worldartCinemaId = null,
        string? worldartLink = null,
        string? playerLink = null,
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
        string? prioritizeTranslations = null,
        string? unprioritizeTranslations = null,
        string? blockTranslations = null,
        string? prioritizeTranslationType = null,
        // Рейтинги
        float? kinopoiskRating = null,
        float? imdbRating = null,
        float? shikimoriRating = null,
        // Сезоны и серии
        int? season = null,
        int? episode = null,
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
        string? hasField = null,
        string? hasFields = null,
        string? hasFieldAnd = null,
        string? notBlockedIn = null,
        bool? notBlockedForMe = null, // Обычно передается как флаг (true/false)
        string? licensedBy = null,
        // Сортировка
        string? sort = null,
        string? order = null,
        // ДОПОЛНИТЕЛЬНЫЕ ПАРАМЕТРЫ (Расширение ответа)
        bool? withMaterialData = null,
        bool? withSeasons = null,
        bool? withEpisodes = null,
        bool? withEpisodesData = null,
        bool? withPageLinks = null 
    ){
         var url = "https://kodik-api.com/list"
            .SetQueryParam("token", _apiToken);

        // Базовые параметры поиска и лимиты
        if (limit != null) url = url.SetQueryParam("limit", limit);
        if (title != null) url = url.SetQueryParam("title", title);
        if (titleOrig != null) url = url.SetQueryParam("title_orig", titleOrig);
        if (strict != null) url = url.SetQueryParam("strict", strict);
        if (fullMatch != null) url = url.SetQueryParam("full_match", fullMatch);

        // Идентификаторы
        if (shikimoriId != null) url = url.SetQueryParam("shikimori_id", shikimoriId);
        if (kinopoiskId != null) url = url.SetQueryParam("kinopoisk_id", kinopoiskId);
        if (imdbId != null) url = url.SetQueryParam("imdb_id", imdbId);
        if (id != null) url = url.SetQueryParam("id", id);
        if (mdlId != null) url = url.SetQueryParam("mdl_id", mdlId);
        if (worldartAnimationId != null) url = url.SetQueryParam("worldart_animation_id", worldartAnimationId);
        if (worldartCinemaId != null) url = url.SetQueryParam("worldart_cinema_id", worldartCinemaId);
        if (worldartLink != null) url = url.SetQueryParam("worldart_link", worldartLink);
        if (playerLink != null) url = url.SetQueryParam("player_link", playerLink);

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
        if (prioritizeTranslations != null) url = url.SetQueryParam("prioritize_translations", prioritizeTranslations);
        if (unprioritizeTranslations != null) url = url.SetQueryParam("unprioritize_translations", unprioritizeTranslations);
        if (blockTranslations != null) url = url.SetQueryParam("block_translations", blockTranslations);
        if (prioritizeTranslationType != null) url = url.SetQueryParam("prioritize_translation_type", prioritizeTranslationType);

        // Рейтинги
        if (kinopoiskRating != null) url = url.SetQueryParam("kinopoisk_rating", kinopoiskRating);
        if (imdbRating != null) url = url.SetQueryParam("imdb_rating", imdbRating);
        if (shikimoriRating != null) url = url.SetQueryParam("shikimori_rating", shikimoriRating);

        // Сезоны и серии
        if (season != null) url = url.SetQueryParam("season", season);
        if (episode != null) url = url.SetQueryParam("episode", episode);

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
        if (hasField != null) url = url.SetQueryParam("has_field", hasField);
        if (hasFields != null) url = url.SetQueryParam("has_fields", hasFields);
        if (hasFieldAnd != null) url = url.SetQueryParam("has_field_and", hasFieldAnd);
        if (notBlockedIn != null) url = url.SetQueryParam("not_blocked_in", notBlockedIn);
        if (notBlockedForMe != null) url = url.SetQueryParam("not_blocked_for_me", notBlockedForMe);
        if (licensedBy != null) url = url.SetQueryParam("licensed_by", licensedBy);

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
}