public class PingApiBackgroundService: BackgroundService{
    private ISearchService _apiService;
    private ApiHelthService _apiHelthService;

    public PingApiBackgroundService(ISearchService searchService, ApiHelthService apiHelthService){
        _apiService = searchService;
        _apiHelthService = apiHelthService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken){
        while(true){
            try{
                _apiHelthService.Helth = await _apiService.Ping();
            }catch(Exception e){
                _apiHelthService.Helth = false;   
            }
            await Task.Delay(1000000, stoppingToken); 
        }
    }
}