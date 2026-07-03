using Microsoft.EntityFrameworkCore;

public class CinemaDbContext : DbContext 
{
    public DbSet<FilmEntity> Films { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<ActorEntity> Actors { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WatchListUserEntity> WatchListUsers { get; set; }
    public DbSet<SystemSettingsEntity> SystemSettings { get; set; }
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) 
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}