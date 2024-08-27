using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Permissions;

public sealed class Permission : EntityInt
{
    private Permission(){}

    public Permission (int id, string nombre) : base(id)
    {
        Nombre = nombre;
    }

    public Permission (string nombre) : base() 
    {
        Nombre = nombre;
    }
    public string? Nombre { get; init; }

    public static Result<Permission> Create (
        string nombre
    )
    {
        return new Permission( nombre ); 
    }

}