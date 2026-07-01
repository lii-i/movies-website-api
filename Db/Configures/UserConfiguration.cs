using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);

        // Логин должен быть обязательным, уникальным и не очень длинным
        builder.Property(u => u.login).IsRequired().HasMaxLength(50);
        builder.HasIndex(u => u.login).IsUnique();

        builder.Property(u => u.password).IsRequired();
    }
}