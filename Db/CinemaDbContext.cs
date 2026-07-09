using Microsoft.EntityFrameworkCore;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

    // Главная сущность
    public DbSet<AnimeItemsEntity> AnimeItems { get; set; }

    // Справочники
    public DbSet<GenresEntity> Genres { get; set; }
    public DbSet<AnimeStudiosEntity> AnimeStudios { get; set; }
    public DbSet<CharactersEntity> Characters { get; set; }
    public DbSet<PersonsEntity> Persons { get; set; }
    public DbSet<MangaEntity> Manga { get; set; }
    public DbSet<FundubbersEntity> Fundubbers { get; set; }
    public DbSet<FunsubbersEntity> Funsubbers { get; set; }

    // Связи M:M
    public DbSet<AnimeGenresEntity> AnimeGenres { get; set; }
    public DbSet<AnimeStudiosRelatedEntity> AnimeStudiosRelated { get; set; }
    public DbSet<CharactersRelatedEntity> CharactersRelated { get; set; }
    public DbSet<PersonsRelatedEntity> PersonsRelated { get; set; }
    public DbSet<FundubbersRelatedEntity> FundubbersRelated { get; set; }
    public DbSet<FunsubbersRelatedEntity> FunsubbersRelated { get; set; }
    public DbSet<AnimeRelatesEntity> AnimeRelates { get; set; }
    public DbSet<MangaRelatedEntity> MangaRelated { get; set; }

    // Зависимые 1:M
    public DbSet<VideosEntity> Videos { get; set; }
    public DbSet<ScreenshotsEntity> Screenshots { get; set; }
    public DbSet<ScoreStatsEntity> ScoreStats { get; set; }
    public DbSet<StatusesStatsEntity> StatusesStats { get; set; }
    public DbSet<ExternalLinksEntity> ExternalLinks { get; set; }

    // Пользователи
    public DbSet<UsersEntity> Users { get; set; }
    public DbSet<WatchListUsersEntity> WatchListUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // AnimeGenres → Genres + AnimeItems
        modelBuilder.Entity<AnimeGenresEntity>()
            .HasOne<GenresEntity>().WithMany().HasForeignKey(x => x.IdGenres);
        modelBuilder.Entity<AnimeGenresEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        // AnimeStudiosRelated → AnimeStudios + AnimeItems
        modelBuilder.Entity<AnimeStudiosRelatedEntity>()
            .HasOne<AnimeStudiosEntity>().WithMany().HasForeignKey(x => x.IdAnimeStudio);
        modelBuilder.Entity<AnimeStudiosRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        // CharactersRelated → Characters + AnimeItems
        modelBuilder.Entity<CharactersRelatedEntity>()
            .HasOne<CharactersEntity>().WithMany().HasForeignKey(x => x.IdCharacter);
        modelBuilder.Entity<CharactersRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        // PersonsRelated → Persons + AnimeItems
        modelBuilder.Entity<PersonsRelatedEntity>()
            .HasOne<PersonsEntity>().WithMany().HasForeignKey(x => x.IdPerson);
        modelBuilder.Entity<PersonsRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        // FundubbersRelated → Fundubbers + AnimeItems
        modelBuilder.Entity<FundubbersRelatedEntity>()
            .HasOne<FundubbersEntity>().WithMany().HasForeignKey(x => x.IdFundubbers);
        modelBuilder.Entity<FundubbersRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        // FunsubbersRelated → Funsubbers + AnimeItems
        modelBuilder.Entity<FunsubbersRelatedEntity>()
            .HasOne<FunsubbersEntity>().WithMany().HasForeignKey(x => x.IdFunsubbers);
        modelBuilder.Entity<FunsubbersRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        // AnimeRelates → AnimeItems (само-ссылка: аниме ↔ аниме)
        modelBuilder.Entity<AnimeRelatesEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnime1).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<AnimeRelatesEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnime2).OnDelete(DeleteBehavior.Restrict);

        // MangaRelated → Manga + AnimeItems
        modelBuilder.Entity<MangaRelatedEntity>()
            .HasOne<MangaEntity>().WithMany().HasForeignKey(x => x.MangaId);
        modelBuilder.Entity<MangaRelatedEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);

        // 1:M зависимые таблицы
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

        // WatchListUsers → Users + AnimeItems
        modelBuilder.Entity<WatchListUsersEntity>()
            .HasOne<UsersEntity>().WithMany().HasForeignKey(x => x.IdUser);
        modelBuilder.Entity<WatchListUsersEntity>()
            .HasOne<AnimeItemsEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);
    }
}
