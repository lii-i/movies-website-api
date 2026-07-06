public class KodikSearchRequestParamDTO{
    public ParamSearch search {get; set;}
    public ParamSearchList searchList {get; set;}
}

public class ParamSearch {
    string? title = null;
    string? titleOrig = null;
    string? id = null;
    string? shikimoriId = null;
    string? kinopoiskId = null;
    string? imdbId = null;
    string? mdlId = null;
    string? worldartAnimationId = null;
    string? worldartLink = null;
    string? playerLink = null;

    // Уточнение поиска
    bool? strict = null;
    bool? fullMatch = null;
    int? limit = null;
    string? types = null;
    int? year = null;
    bool? lgbt = null;
    string? anime_kind = null;
    string? anime_status = null;
    string? rating_mpaa = null;
    int? minimal_age = null;
    double? kinopoisk_rating = null;
    double? imdb_rating = null;
    double? shikimori_rating = null;
    string? anime_studios = null;
    string? genres = null;
    string? anime_genres = null;
    int? duration = null;
    string? has_field_and = null;
    string? prioritize_translations = null;
    string? unprioritize_translations = null; 
    string? block_translations = null;
    int? season = null;
    string? countries = null;

    // Съемочная группа
    string? actors = null;
    string? directors = null;
    string? producers = null;
    string? writers = null;
    string? composers = null;
    string? editors = null;
    string? designers = null;
    string? operators = null;

    // Контентные уточнения
    int? translationId = null;
    string? translationType = null;
    bool? camrip = null;
    string? mydramalist_tags = null;

    // Дополнительные данные
    bool? withMaterialData = null;
    bool? withSeasons = null;
    bool? withEpisodes = null;
    bool? withEpisodesData = null;
    bool? withPageLinks = null;

}

public class ParamSearchList {
    // Базовые параметры поиска и лимиты
    int? limit = null;
    // Характеристики контента
    string? types = null;
    int? year = null;
    bool? camrip = null;
    bool? lgbt = null;
    string? animeKind = null;
    string? animeStatus = null;
    string? mydramalistTags = null;
    string? ratingMpaa = null;
    int? minimalAge = null;
    int? duration = null;
    string? countries = null;
    string? genres = null;
    string? animeGenres = null;
    string? animeStudios = null;
    // Переводы и озвучки
    int? translationId = null;
    string? translationType = null;
    string? blockTranslations = null;
    // Рейтинги
    double? kinopoiskRating = null;
    double? imdbRating = null;
    double? shikimoriRating = null;
    // Съемочная группа
    string? actors = null;
    string? directors = null;
    string? producers = null;
    string? writers = null;
    string? composers = null;
    string? editors = null;
    string? designers = null;
    string? operators = null;
    // Наличие полей; блокировки и прочее
    string? hasFieldAnd = null;
    // Сортировка
    string? sort = null;
    string? order = null;
    // ДОПОЛНИТЕЛЬНЫЕ ПАРАМЕТРЫ (Расширение ответа)
    bool? withMaterialData = null;
    bool? withSeasons = null;
    bool? withEpisodes = null;
    bool? withEpisodesData = null;
    bool? withPageLinks = null;
}