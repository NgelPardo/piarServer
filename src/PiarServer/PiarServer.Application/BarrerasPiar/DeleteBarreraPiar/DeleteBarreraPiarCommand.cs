using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.BarrerasPiar.DeleteBarreraPiar;

public sealed record DeleteBarreraPiarCommand(Guid Id) : ICommand<Guid>;