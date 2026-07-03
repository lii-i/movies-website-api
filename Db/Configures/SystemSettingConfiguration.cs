using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SystemSettingConfiguration : IEntityTypeConfiguration<SystemSettingsEntity>{
    public void Configure(EntityTypeBuilder<SystemSettingsEntity> builder){
        builder.HasKey(s => s.NameSettings);
        builder.Property(s => s.NameSettings).HasMaxLength(50);

        builder.Property(s=>s.Value).IsRequired();
    }
}