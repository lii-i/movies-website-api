using Microsoft.EntityFrameworkCore;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

    public DbSet<VideoItems> VideoItems { get; set; }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<VideoGenres> VideoGenres { get; set; }
    public DbSet<Actors> Actors { get; set; }
    public DbSet<ActorsVideo> ActorsVideo { get; set; }
    public DbSet<Directors> Directors { get; set; }
    public DbSet<DirectorsVideo> DirectorsVideo { get; set; }
    public DbSet<Producers> Producers { get; set; }
    public DbSet<ProducersVideo> ProducersVideo { get; set; }
    public DbSet<AnimeStudios> AnimeStudios { get; set; }
    public DbSet<AnimeStudiosVideo> AnimeStudiosVideo { get; set; }
    public DbSet<Countries> Countries { get; set; }
    public DbSet<VideoCountries> VideoCountries { get; set; }
    public DbSet<BlockedCountries> BlockedCountries { get; set; }
    public DbSet<BlockedSeasons> BlockedSeasons { get; set; }
    public DbSet<Screenshots> Screenshots { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<WatchListUsers> WatchListUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VideoGenres>()
            .HasOne<Genres>().WithMany().HasForeignKey(x => x.IdGenres);
        modelBuilder.Entity<VideoGenres>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<ActorsVideo>()
            .HasOne<Actors>().WithMany().HasForeignKey(x => x.IdActors);
        modelBuilder.Entity<ActorsVideo>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<DirectorsVideo>()
            .HasOne<Directors>().WithMany().HasForeignKey(x => x.IdDirectors);
        modelBuilder.Entity<DirectorsVideo>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<ProducersVideo>()
            .HasOne<Producers>().WithMany().HasForeignKey(x => x.IdProducers);
        modelBuilder.Entity<ProducersVideo>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<AnimeStudiosVideo>()
            .HasOne<AnimeStudios>().WithMany().HasForeignKey(x => x.IdAnimeStudio);
        modelBuilder.Entity<AnimeStudiosVideo>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<CountriesCreated>()
            .HasOne<Countries>().WithMany().HasForeignKey(x => x.IdCountry);
        modelBuilder.Entity<CountriesCreated>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<BlockedCountries>()
            .HasOne<Countries>().WithMany().HasForeignKey(x => x.IdCountry);
        modelBuilder.Entity<BlockedCountries>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<BlockedSeasons>()
            .HasOne<Countries>().WithMany().HasForeignKey(x => x.IdCountry);
        modelBuilder.Entity<BlockedSeasons>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<Screenshots>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);

        modelBuilder.Entity<WatchListUsers>()
            .HasOne<Users>().WithMany().HasForeignKey(x => x.IdUser);
        modelBuilder.Entity<WatchListUsers>()
            .HasOne<VideoItems>().WithMany().HasForeignKey(x => x.IdVideoItem);
    }
}
