public class CinemaDbContext : DbContext 
{
    public DbSet<FilmEntity> Films { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WatchListUserEntity> WatchListUsers { get; set; }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) 
    {
    }

    public override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        // 1. Настройка промежуточной таблицы Watchlist
        modelBuilder.Entity<WatchListUserEntity>()
            .HasKey(w => new { w.UserId, w.FilmId });
    
        modelBuilder.Entity<WatchListUserEntity>()
            .HasOne(w => w.User)
            .WithMany(u => u.WatchlistItems) // Теперь имена совпадают!
            .HasForeignKey(w => w.UserId);
        
        modelBuilder.Entity<WatchListUserEntity>()
            .HasOne(w => w.Film)
            .WithMany() 
            .HasForeignKey(w => w.FilmId);
            
        base.OnModelCreating(modelBuilder);
    }
}