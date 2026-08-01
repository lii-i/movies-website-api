using Microsoft.EntityFrameworkCore;

public class Program {
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var Config = builder.Configuration;

        builder.Services.AddDbContext<CinemaDbContext>(options => options.UseNpgsql(Config.GetConnectionString("PostgreSql"))); 
        //builder.Services.AddScoped<IRepository,Repository>();
        builder.Services.AddSingleton<ISearchService, ApiAgregatorShikimoriKodikSearch>(delProvider => {
            // потом еще логгер надо зарегать
            return new ApiAgregatorShikimoriKodikSearch(Config["Tokens:Kodik"], Config["URLs:Shikimori"], Config["URLs:Kodik:Search"], Config["URLs:Kodik:List"]);
        });
        builder.Services.AddScoped<IRepository, Repository>();
        builder.Services.AddScoped<AnimeService>();
        var app = builder.Build();

        using (var scope = app.Services.CreateScope()){
            var db = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
            await db.Database.MigrateAsync();
        };


        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.MapGet("/error", () => "error");
        }
    
        app.UseDefaultFiles();   
        app.UseStaticFiles();   

        app.AddMoviesEndPoints();
        app.Run();
    }
}
