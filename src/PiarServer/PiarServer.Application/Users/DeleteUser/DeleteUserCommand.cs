using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Users.DeleteUser;

public sealed record DeleteUserCommand( Guid Id ) : ICommand<Guid>;