using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

    public DbSet<AnimeEntity> Animes { get; set; }
    public DbSet<UsersEntity> Users { get; set; }
    public DbSet<WatchListUsersEntity> WatchListUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimeEntity>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).ValueGeneratedNever();

            entity.Property(a => a.Synonyms).HasColumnType("text[]");
            entity.Property(a => a.Genres).HasColumnType("text[]");
            entity.Property(a => a.Studios).HasColumnType("text[]");
            entity.Property(a => a.Cast).HasColumnType("text[]");
            entity.Property(a => a.Screenshots).HasColumnType("text[]");

            var relatedComparer = new ValueComparer<List<RelatedAnimeDTO>>(
                (a, b) => JsonSerializer.Serialize(a, (JsonSerializerOptions?)null) == JsonSerializer.Serialize(b, (JsonSerializerOptions?)null),
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null).GetHashCode(),
                v => JsonSerializer.Deserialize<List<RelatedAnimeDTO>>(JsonSerializer.Serialize(v, (JsonSerializerOptions?)null), (JsonSerializerOptions?)null) ?? new()
            );
            entity.Property(a => a.Related)
                .HasColumnType("jsonb")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<RelatedAnimeDTO>>(v, (JsonSerializerOptions?)null) ?? new()
                )
                .Metadata.SetValueComparer(relatedComparer);
        });

        modelBuilder.Entity<WatchListUsersEntity>()
            .HasOne<UsersEntity>().WithMany().HasForeignKey(x => x.IdUser);
        modelBuilder.Entity<WatchListUsersEntity>()
            .HasOne<AnimeEntity>().WithMany().HasForeignKey(x => x.IdAnimeItem);
    }
}
