using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Permissions;
using PiarServer.Domain.Roles;

namespace PiarServer.Infrastructure.Configurations;

public sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("roles_permissions");
        builder.HasKey(x => new { x.RoleId, x.PermissionId });

        builder.HasData(
            Create(Role.Auxiliar, PermissionEnum.ReadUser),
            Create(Role.Profesor, PermissionEnum.ReadUser),
            Create(Role.Profesor, PermissionEnum.WriteUser),
            Create(Role.Admin, PermissionEnum.ReadUser),
            Create(Role.Admin, PermissionEnum.WriteUser),
            Create(Role.Admin, PermissionEnum.UpdateUser),
            Create(Role.SuperAdmin, PermissionEnum.ReadUser),
            Create(Role.SuperAdmin, PermissionEnum.WriteUser),
            Create(Role.SuperAdmin, PermissionEnum.UpdateUser)
        );

    }

    private static RolePermission Create(Role role, PermissionEnum permission)
    {
        
        return new RolePermission
        {
            RoleId = role.Id,
            PermissionId = (int)permission
        };
    }
}