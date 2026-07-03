using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ActorConfiguration : IEntityTypeConfiguration<ActorEntity>
{
    public void Configure(EntityTypeBuilder<ActorEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasMany(a => a.Films)
               .WithMany(f => f.Cast)
               .UsingEntity(j => j.ToTable("FilmActors"));
    }
}
