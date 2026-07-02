public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var Config = builder.Configuration;

        builder.Services.AddDbContext<CinemaDbContext>(options => options.UsePostgreSql(Config.GetConnectionString("PostgreSql"))); 
        builder.Services.AddScoped<IRepository,Repository>();
        var app = builder.Build();

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

        app.Run();
    }
}
