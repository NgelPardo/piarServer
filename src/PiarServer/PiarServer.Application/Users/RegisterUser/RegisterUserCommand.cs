using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Users.RegisterUser;

public sealed record RegisterUserCommand( 
    string Email, 
    string Nombre, 
    string Apellido, 
    string Password, 
    int Rol ) : ICommand<Guid>;