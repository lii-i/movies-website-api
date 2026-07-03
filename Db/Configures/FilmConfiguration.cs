using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FilmConfiguration : IEntityTypeConfiguration<FilmEntity>
{
    public void Configure(EntityTypeBuilder<FilmEntity> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Title).IsRequired().HasMaxLength(250);
        builder.Property(f => f.OriginalTitle).HasMaxLength(250);

        builder.HasMany(f => f.Genres)
               .WithMany(g => g.Films)
               .UsingEntity(j => j.ToTable("FilmGenres"));
    }
}