using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Permissions;

namespace PiarServer.Infrastructure.Configurations;

public sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");
        builder.HasKey(x => x.Id);
    
        IEnumerable<Permission> permissions = Enum.GetValues<PermissionEnum>().Select(p => new Permission( (int)p, p.ToString()));

        builder.HasData(permissions);


    }
}