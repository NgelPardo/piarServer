using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Roles;
using PiarServer.Domain.Users;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey( user => user.Id );

        builder.OwnsOne(user => user.Nombre);
        builder.OwnsOne(user => user.Apellido);

        builder.Property(user => user.Email)
            .HasMaxLength(200)
            .HasConversion(email => email!.Value, value=> new Domain.Users.Email(value));

        builder.Property(user => user.PasswordHash)
            .HasMaxLength(2000)
            .HasConversion(password => password!.Value, value=> new PasswordHash(value));

        builder.HasIndex(user => user.Email).IsUnique();

        builder.HasMany(x => x.Roles)
            .WithMany()
            .UsingEntity<UserRole>(
                j => j.HasOne<Role>().WithMany().HasForeignKey(ur => ur.RoleId),
                j => j.HasOne<User>().WithMany().HasForeignKey(u => u.idUss)
            );
    }
}