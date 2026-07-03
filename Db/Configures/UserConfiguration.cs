using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Login).IsRequired().HasMaxLength(50);
        builder.HasIndex(u => u.Login).IsUnique();

        builder.Property(u => u.Password).IsRequired();
    }
}