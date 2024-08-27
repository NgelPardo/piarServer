using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Users.UpdateUser;
public record UpdateUserCommand(
    Guid Id,
    string Nombre,
    string Apellido,
    int Rol) : ICommand<Guid>;