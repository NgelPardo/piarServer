using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Barreras.DeleteBarrera;

public sealed record DeleteBarreraCommand(Guid Id) : ICommand<Guid>;