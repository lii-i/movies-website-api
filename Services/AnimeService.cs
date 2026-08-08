public class AnimeService
{
    private readonly IServiceProvider _services;

    public AnimeService(IServiceProvider Services)
    {
       _services = Services;
    }

    public async Task<SearchResponseDTO> SearchAsync(SearchRequestParamDTO requestParam){

        ISearchService searchService = _services.GetRequiredService<ISearchService>();

        bool ping = await searchService.Ping();
        if(ping){
            SearchResponseDTO responseAPI = await searchService.SearchAPIAsync(requestParam);
            AddOrUpdateAnimeAsync(responseAPI);
            return responseAPI;
        }
        
        return await DbGetAnimeByFiltersAsync(requestParam);
    }

    public async Task<SearchResponseDTO> DbGetAnimeByFiltersAsync(SearchRequestParamDTO requestParam)
    {
        using(var scope = _services.CreateScope()){
            try{
                var rep = scope.ServiceProvider.GetRequiredService<IRepository>();
                List<AnimeEntity> responseBD = await rep.GetAnimeByFiltersAsync(requestParam);
                return new SearchResponseDTO
                {
                    Items = responseBD.Select(a => new AnimeResponseDTO
                    {
                        Id = a.Id,
                        MalId = a.MalId,
                        Title = a.Title,
                        OriginalTitle = a.OriginalTitle,
                        TitleEn = a.TitleEn,
                        TitleJap = a.TitleJap,
                        Synonyms = a.Synonyms,
                        Poster = a.Poster,
                        PosterOriginal = a.PosterOriginal,
                        Backdrop = a.Backdrop,
                        Rating = a.Rating,
                        AgeRating = a.AgeRating,
                        Kind = a.Kind,
                        Status = a.Status,
                        Season = a.Season,
                        Year = a.Year,
                        AiredOn = a.AiredOn,
                        ReleasedOn = a.ReleasedOn,
                        Episodes = a.Episodes,
                        EpisodesAired = a.EpisodesAired,
                        Duration = a.Duration,
                        Genres = a.Genres,
                        Director = a.Director,
                        Studios = a.Studios,
                        Cast = a.Cast,
                        Description = a.Description,
                        DescriptionHtml = a.DescriptionHtml,
                        Censored = a.Censored,
                        EmbedUrl = a.EmbedUrl,
                        Screenshots = a.Screenshots,
                        Related = a.Related
                    }).ToList()
                };
            }catch(Exception e){
                Console.WriteLine(e.Message);
                throw e;
            }   
        }
    }

    public async Task AddOrUpdateAnimeAsync(SearchResponseDTO responseAPI){

        Task.Run(async () =>{
            using(var scope = _services.CreateScope()){
                var rep = scope.ServiceProvider.GetRequiredService<IRepository>();    
                try{
                    foreach(var item in responseAPI.Items){
                        await rep.AddOrUpdateAnimeAsync(item);
                    }
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Cохранение в бд не удалось");
                    throw e;  
                }
            }
        }
        );
    }
}