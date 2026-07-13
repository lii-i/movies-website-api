using Microsoft.EntityFrameworkCore;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }


    public DbSet<AnimeItemsEntity> AnimeItems { get; set; }

    public DbSet<GenresEntity> Genres { get; set; }
    public DbSet<AnimeStudiosEntity> AnimeStudios { get; set; }
    public DbSet<CharactersEntity> Characters { get; set; }
    public DbSet<PersonsEntity> Persons { get; set; }
    public DbSet<MangaEntity> Manga { get; set; }
    public DbSet<FundubbersEntity> Fundubbers { get; set; }
    public DbSet<FunsubbersEntity> Funsubbers { get; set; }

    public DbSet<AnimeGenresEntity> AnimeGenres { get; set; }
    public DbSet<AnimeStudiosRelatedEntity> AnimeStudiosRelated { get; set; }
    public DbSet<CharactersRelatedEntity> CharactersRelated { get; set; }
    public DbSet<PersonsRelatedEntity> PersonsRelated { get; set; }
    public DbSet<FundubbersRelatedEntity> FundubbersRelated { get; set; }
    public DbSet<FunsubbersRelatedEntity> FunsubbersRelated { get; set; }
    public DbSet<AnimeRelatesEntity> AnimeRelates { get; set; }
    public DbSet<MangaRelatedEntity> MangaRelated { get; set; }

    public DbSet<VideosEntity> Videos { get; set; }
    public DbSet<ScreenshotsEntity> Screenshots { get; set; }
    public DbSet<ScoreStatsEntity> ScoreStats { get; set; }
    public DbSet<StatusesStatsEntity> StatusesStats { get; set; }
    public DbSet<ExternalLinksEntity> ExternalLinks { get; set; }

    public DbSet<UsersEntity> Users { get; set; }
    public DbSet<WatchListUsersEntity> WatchListUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimeItemsEntity>()
            .HasKey(a => a.ShikimoriId);
        modelBuilder.Entity<AnimeItemsEntity>()
            .Property(a => a.ShikimoriId)
            .ValueGeneratedNever();

        modelBuilder.Entity<AnimeGenresEntity>()
            .HasOne<GenresEntity>().WithMany().HasForeignKey(x => x.IdGenres);
        modelBuilder.Entity<AnimeGenresEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        modelBuilder.Entity<AnimeStudiosRelatedEntity>()
            .HasOne<AnimeStudiosEntity>().WithMany().HasForeignKey(x => x.IdAnimeStudio);
        modelBuilder.Entity<AnimeStudiosRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        modelBuilder.Entity<CharactersRelatedEntity>()
            .HasOne<CharactersEntity>().WithMany().HasForeignKey(x => x.IdCharacter);
        modelBuilder.Entity<CharactersRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        modelBuilder.Entity<PersonsRelatedEntity>()
            .HasOne<PersonsEntity>().WithMany().HasForeignKey(x => x.IdPerson);
        modelBuilder.Entity<PersonsRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        modelBuilder.Entity<FundubbersRelatedEntity>()
            .HasOne<FundubbersEntity>().WithMany().HasForeignKey(x => x.IdFundubbers);
        modelBuilder.Entity<FundubbersRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        modelBuilder.Entity<FunsubbersRelatedEntity>()
            .HasOne<FunsubbersEntity>().WithMany().HasForeignKey(x => x.IdFunsubbers);
        modelBuilder.Entity<FunsubbersRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        modelBuilder.Entity<AnimeRelatesEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnime1).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<AnimeRelatesEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnime2).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MangaRelatedEntity>()
            .HasOne<MangaEntity>().WithMany().HasForeignKey(x => x.MangaId);
        modelBuilder.Entity<MangaRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        modelBuilder.Entity<VideosEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);
        modelBuilder.Entity<ScreenshotsEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);
        modelBuilder.Entity<ScoreStatsEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);
        modelBuilder.Entity<StatusesStatsEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);
        modelBuilder.Entity<ExternalLinksEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        modelBuilder.Entity<WatchListUsersEntity>()
            .HasOne<UsersEntity>().WithMany().HasForeignKey(x => x.IdUser);
        modelBuilder.Entity<WatchListUsersEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);
    }
}
