using PiarServer.Domain.Permissions;
using PiarServer.Domain.Shared;

namespace PiarServer.Domain.Roles;

public sealed class Role : Enumeration<Role>
{
    public static readonly Role SuperAdmin = new(1, "SuperAdmin");
    public static readonly Role Admin = new(2, "Admin");
    public static readonly Role Profesor = new(3, "Profesor");
    public static readonly Role Auxiliar = new(4, "Auxiliar");
    public Role(int id, string name) : base(id, name)
    {
    }
    public ICollection<Permission>? Permissions { get; set; }
}