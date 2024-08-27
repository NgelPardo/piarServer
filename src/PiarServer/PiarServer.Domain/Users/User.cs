using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Roles;
using PiarServer.Domain.Users.Events;

namespace PiarServer.Domain.Users;
public sealed class User : Entity
{
    private User(){}
    private User( 
        Guid id,
        Nombre nombre,
        Apellido apellido,
        
        Email email,
        PasswordHash passwordHash,
        DateTime? fecDil
        ): base(id)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        PasswordHash = passwordHash;
        FecDil = fecDil;
    }

    private User(
        Nombre nombre,
        Apellido apellido
        )
    {
        Nombre = nombre;
        Apellido = apellido;
    }
    public Nombre? Nombre {get; private set;}
    public Apellido? Apellido {get; private set;}
    public Email? Email {get; private set;}
    public PasswordHash? PasswordHash {get; private set;}
    public DateTime? FecDil {get; private set;}
    public static User Create(
        Nombre nombre,
        Apellido apellido,
        Email email,
        PasswordHash passwordHash,
        DateTime? fecDil,
        string? passwordNoHash
    )
    {
        var user = new User(
            Guid.NewGuid(),
            nombre, 
            apellido, 
            email, 
            passwordHash, 
            fecDil
        );
        user.RaiseDomainEvent(new UserCreatedDomainEvent( user.Id!, passwordNoHash!));
        return user;
    }

    public void Update(
        Nombre nombre,
        Apellido apellido
    )
    {
        Nombre = nombre;
        Apellido = apellido;
    }

    public ICollection<Role>? Roles {get; set;}

}