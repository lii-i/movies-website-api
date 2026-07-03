using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WatchListUserConfiguration : IEntityTypeConfiguration<WatchListUserEntity>
{
    public void Configure(EntityTypeBuilder<WatchListUserEntity> builder)
    {
        builder.HasKey(w => new { w.UserId, w.FilmId });

        builder.HasOne(w => w.User)
               .WithMany(u => u.WatchlistItems)
               .HasForeignKey(w => w.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(w => w.Film)
               .WithMany()
               .HasForeignKey(w => w.FilmId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}