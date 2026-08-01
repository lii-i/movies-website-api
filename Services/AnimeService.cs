public class AnimeService
{
    private readonly IServiceProvider _services;

    public AnimeService(IServiceProvider Services)
    {
       _services = Services;
    }

    public async Task<AnimeEntity> GetAnimeByIdAsync(int id){
        using(var scope = _services.CreateScope()){
            try{
            var rep = scope.ServiceProvider.GetRequiredService<IRepository>();
            return await rep.GetAnimeByIdAsync(id);
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }

    public async Task<List<AnimeEntity>> GetAnimeByFiltersAsync(SearchRequestParamDTO requestParam)
    {
        using(var scope = _services.CreateScope()){
            try{
                var rep = scope.ServiceProvider.GetRequiredService<IRepository>();
                rep.GetAnimeByFiltersAsync(requestParam);
                return await rep.GetAnimeByFiltersAsync(requestParam);
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return new List<AnimeEntity>();
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
                }
            }
        }
        );
    }
}