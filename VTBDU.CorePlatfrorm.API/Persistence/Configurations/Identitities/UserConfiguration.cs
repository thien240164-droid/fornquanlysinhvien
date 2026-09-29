using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VTBDU.CorePlatform.Domain.Entities.Identity;

namespace VTBDU.CorePlatform.Infrastructure.Persistence.Configurations.Identities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(x => x.Username)
            .IsUnique();

        builder.Property(x => x.PasswordHash)
            .IsRequired();

        builder.HasOne(x => x.Language)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.LanguageId);
    }
}