using Microsoft.AspNetCore.Mvc;
    public static class MoviesEndPoints{
        public static WebApplication AddMoviesEndPoints(this WebApplication app){
        app.MapGet("/search", async (
        [FromServices] IAgregatorApiService<ShikimoriSearchResponseDTO, ShikimoriSearchRequestParamDTO> ApiAgregator,
        [FromQuery(Name="title")] string? title,
        [FromQuery(Name="limit")] int? limit,
        [FromQuery(Name="minRating")] int? minRating,
        [FromQuery(Name="duration")] string? duration, 
        [FromQuery(Name="genres")] string? genres,
        [FromQuery(Name="mpaaRating")] string? mpaaRating
        ) =>{
            SearchRequestParamDTO<ShikimoriSearchRequestParamDTO> searchParam = new SearchRequestParamDTO<ShikimoriSearchRequestParamDTO>();
            searchParam.SearchRequestParam = new ShikimoriSearchRequestParamDTO{
                Title = title,
                Limit = limit,
                Score = minRating,
                Duration = duration,
                Genre = genres,
                Rating = mpaaRating
            };

            var responseAPI = await ApiAgregator.Search(searchParam);

            List<AnimeItemsEntity> response = new List<AnimeItemsEntity> (responseAPI.Response.Animes.Count);

            foreach(var anime in responseAPI.Response.Animes){
                AnimeItemsEntity a = new AnimeItemsEntity {
                ShikimoriId = Convert.ToInt32(anime.Id),
                MalId = Convert.ToInt32(anime.MalId),
                Title = anime.Name,
                TitleRus = anime.Russian,
                TitleEn = anime.English,
                TitleJap = anime.Japanese,
                Synonyms = string.Join(", ", anime.Synonyms),
                LicenseNameRu = anime.LicenseNameRu,
                Kind = anime.Kind,
                Rating = anime.Rating,
                Score = anime.Score,
                Status = anime.Status,
                Episodes = anime.Episodes,
                EpisodesAired = anime.EpisodesAired,
                Duration = anime.Duration,
                AiredOn = DateOnly.TryParse(anime.AiredOn?.Date, out var airedOn) ? airedOn : null,
                ReleasedOn = DateOnly.TryParse(anime.ReleasedOn?.Date, out var releasedOn) ? releasedOn : null,
                Url = anime.Url,
                Season = anime.Season,
                PosterOriginalUrl = anime.Poster.OriginalUrl,
                PosterMainUrl = anime.Poster.MainUrl,
                Licensors = string.Join(",",anime.Licensors),
                CreatedAt = anime.CreatedAt,
                UpdatedAt = anime.UpdatedAt,
                NextEpisodeAt = anime.NextEpisodeAt,
                IsCensored = anime.IsCensored,
                Description = anime.Description,
                DescriptionHtml = anime.DescriptionHtml,
                DescriptionSource = anime.DescriptionSource,
                PleerLink = anime.PleerLink
                };

                response.Add(a);
                
            }
            
            return TypedResults.Ok(response);
            

        });

        return app;

    }
}