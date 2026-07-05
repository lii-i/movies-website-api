using Microsoft.AspNetCore.Mvc;

public static class MoviesEndPoints{
    public static WebApplication AddMoviesEndPoints(this WebApplication app){
        var movieGroup = app.MapGroup("/search");
        
        movieGroup.MapGet("/", async (
            [FromServices] IAgregatorApiService apiAgregator,
            [FromQuery] string? title = null,
            [FromQuery] string? titleOrig = null,
            [FromQuery] string? id = null,
            [FromQuery] string? shikimoriId = null,
            [FromQuery] string? kinopoiskId = null,
            [FromQuery] string? imdbId = null,
            [FromQuery] string? mdlId = null,
            [FromQuery] string? worldartAnimationId = null,
            [FromQuery] string? worldartLink = null,
            [FromQuery] string? playerLink = null,
            [FromQuery] bool? strict = null,
            [FromQuery] bool? fullMatch = null,
            [FromQuery] int? limit = null,
            [FromQuery] string? types = null,
            [FromQuery] int? year = null,
            [FromQuery] bool? lgbt = null,
            [FromQuery] string? anime_kind = null,
            [FromQuery] string? anime_status = null,
            [FromQuery] string? rating_mpaa = null,
            [FromQuery] int? minimal_age = null,
            [FromQuery] double? kinopoisk_rating = null,
            [FromQuery] double? imdb_rating = null,
            [FromQuery] double? shikimori_rating = null,
            [FromQuery] string? anime_studios = null,
            [FromQuery] string? genres = null,
            [FromQuery] string? anime_genres = null,
            [FromQuery] int? duration = null,
            [FromQuery] string? has_field_and = null,
            [FromQuery] string? prioritize_translations = null,
            [FromQuery] string? unprioritize_translations = null, 
            [FromQuery] string? block_translations = null,
            [FromQuery] int? season = null,
            [FromQuery] string? countries = null,
            [FromQuery] string? actors = null,
            [FromQuery] string? directors = null,
            [FromQuery] string? producers = null,
            [FromQuery] string? writers = null,
            [FromQuery] string? composers = null,
            [FromQuery] string? editors = null,
            [FromQuery] string? designers = null,
            [FromQuery] string? operators = null,
            [FromQuery] int? translationId = null,
            [FromQuery] string? translationType = null,
            [FromQuery] bool? camrip = null,
            [FromQuery] string? mydramalist_tags = null,
            [FromQuery] bool? withMaterialData = null,
            [FromQuery] bool? withSeasons = null,
            [FromQuery] bool? withEpisodes = null,
            [FromQuery] bool? withEpisodesData = null,
            [FromQuery] bool? withPageLinks = null
        ) =>
        {
            if (!limit.HasValue) limit = 20;

            KodikSearchResponse Apiresponse = await apiAgregator.Search(
                title: title,
                titleOrig: titleOrig,
                id: id,
                shikimoriId: shikimoriId,
                kinopoiskId: kinopoiskId,
                imdbId: imdbId,
                mdlId: mdlId,
                worldartAnimationId: worldartAnimationId,
                worldartLink: worldartLink,
                playerLink: playerLink,
                strict: strict,
                fullMatch: fullMatch,
                limit: limit,
                types: types,
                year: year,
                lgbt: lgbt,
                anime_kind: anime_kind,
                anime_status: anime_status,
                rating_mpaa: rating_mpaa,
                minimal_age: minimal_age,
                kinopoisk_rating: kinopoisk_rating,
                imdb_rating: imdb_rating,
                shikimori_rating: shikimori_rating,
                anime_studios: anime_studios,
                genres: genres,
                anime_genres: anime_genres,
                duration: duration,
                has_field_and: has_field_and,
                prioritize_translations: prioritize_translations,
                unprioritize_translations: unprioritize_translations,
                block_translations: block_translations,
                season: season,
                countries: countries,
                actors: actors,
                directors: directors,
                producers: producers,
                writers: writers,
                composers: composers,
                editors: editors,
                designers: designers,
                operators: operators,
                translationId: translationId,
                translationType: translationType,
                camrip: camrip,
                mydramalist_tags: mydramalist_tags,
                withMaterialData: withMaterialData,
                withSeasons: withSeasons,
                withEpisodes: withEpisodes,
                withEpisodesData: withEpisodesData,
                withPageLinks: withPageLinks
            );

            VideoItemsDTO response = new VideoItemsDTO();
            response.PrevPage = Apiresponse.PrevPage;
            response.NextPage = Apiresponse.NextPage;
            response.videoItems = new List<VideoItemDTO>(Apiresponse.Results.Count);

            var ApiListResponse = Apiresponse.Results;
            for(int i =0; i<ApiListResponse.Count; i++){
                response.videoItems.Add(
                new VideoItemDTO 
                {
                    Title = ApiListResponse[i].Title,
                    TitleOrig = ApiListResponse[i].TitleOrig,
                    Type = ApiListResponse[i].Type,
                    TitleEn = ApiListResponse[i].TitleEn,
                    Year = ApiListResponse[i].Year,
                    Link = ApiListResponse[i].Link,
                    LastSeason = ApiListResponse[i].LastSeason,
                    LastEpisode = ApiListResponse[i].LastEpisode,
                    EpisodesCount = ApiListResponse[i].EpisodesCount,
                    AllStatus = ApiListResponse[i].AllStatus,
                    Description = ApiListResponse[i].Description,
                    PosterUrl = ApiListResponse[i].PosterUrl,
                    AnimePosterUrl = ApiListResponse[i].AnimePosterUrl,
                    Duration = ApiListResponse[i].Duration,
                    KinopoiskRating = ApiListResponse[i].KinopoiskRating,
                    KinopoiskVotes = ApiListResponse[i].KinopoiskVotes,
                    ImdbRating = ApiListResponse[i].ImdbRating,
                    ImdbVotes = ApiListResponse[i].ImdbVotes,
                    ShikimoriRating = ApiListResponse[i].ShikimoriRating,
                    ShikimoriVotes = ApiListResponse[i].ShikimoriVotes,
                    Translation = ApiListResponse[i].Translation,
                    PremiereRu = ApiListResponse[i].PremiereRu,
                    PremiereWorld = ApiListResponse[i].PremiereWorld,
                    AiredAt = ApiListResponse[i].AiredAt,
                    ReleasedAt = ApiListResponse[i].ReleasedAt,
                    RatingMpaa = ApiListResponse[i].RatingMpaa,
                    MinimalAge = ApiListResponse[i].MinimalAge,
                    EpisodesTotal = ApiListResponse[i].EpisodesTotal,
                    EpisodesAired = ApiListResponse[i].EpisodesAired
                });
            }

            return Results.Ok(Apiresponse);
        });

        movieGroup.MapGet("/list", async (//[FromServices] IRepository rep,
            [FromServices] IAgregatorApiService apiAgregator,
            [FromQuery] int? limit = null,
            [FromQuery] string? types = null,
            [FromQuery] int? year = null,
            [FromQuery] bool? camrip = null,
            [FromQuery] bool? lgbt = null,
            [FromQuery] string? animeKind = null,
            [FromQuery] string? animeStatus = null,
            [FromQuery] string? mydramalistTags = null,
            [FromQuery] string? ratingMpaa = null,
            [FromQuery] int? minimalAge = null,
            [FromQuery] int? duration = null,
            [FromQuery] string? countries = null,
            [FromQuery] string? genres = null,
            [FromQuery] string? animeGenres = null,
            [FromQuery] string? animeStudios = null,
            [FromQuery] int? translationId = null,
            [FromQuery] string? translationType = null,
            [FromQuery] string? blockTranslations = null,
            [FromQuery] double? kinopoiskRating = null,
            [FromQuery] double? imdbRating = null,
            [FromQuery] double? shikimoriRating = null,
            [FromQuery] string? actors = null,
            [FromQuery] string? directors = null,
            [FromQuery] string? producers = null,
            [FromQuery] string? writers = null,
            [FromQuery] string? composers = null,
            [FromQuery] string? editors = null,
            [FromQuery] string? designers = null,
            [FromQuery] string? operators = null,
            [FromQuery] string? hasFieldAnd = null,
            [FromQuery] string? sort = null,
            [FromQuery] string? order = null,
            [FromQuery] bool? withMaterialData = null,
            [FromQuery] bool? withSeasons = null,
            [FromQuery] bool? withEpisodes = null,
            [FromQuery] bool? withEpisodesData = null,
            [FromQuery] bool? withPageLinks = null 
            ) =>
        {
            if (!limit.HasValue) limit = 20;

            var response = await apiAgregator.SearchList(
                limit: limit,
                types: types,
                year: year,
                camrip: camrip,
                lgbt: lgbt,
                animeKind: animeKind,
                animeStatus: animeStatus,
                mydramalistTags: mydramalistTags,
                ratingMpaa: ratingMpaa,
                minimalAge: minimalAge,
                duration: duration,
                countries: countries,
                genres: genres,
                animeGenres: animeGenres,
                animeStudios: animeStudios,
                translationId: translationId,
                translationType: translationType,
                blockTranslations: blockTranslations,
                kinopoiskRating: kinopoiskRating,
                imdbRating: imdbRating,
                shikimoriRating: shikimoriRating,
                actors: actors,
                directors: directors,
                producers: producers,
                writers: writers,
                composers: composers,
                editors: editors,
                designers: designers,
                operators: operators,
                hasFieldAnd: hasFieldAnd,
                sort: sort,
                order: order,
                withMaterialData: withMaterialData,
                withSeasons: withSeasons,
                withEpisodes: withEpisodes,
                withEpisodesData: withEpisodesData,
                withPageLinks: withPageLinks
            );

            return TypedResults.Ok(response);
            
           
        });

        movieGroup.MapGet("/popular", 
        async (
            //[FromServices] IRepository rep,
            [FromQuery] int? lastId,
            [FromQuery] int? pageSize
        )=>{
           if(!pageSize.HasValue){
            pageSize = 20;
           }


        });

        return app;
    }
}