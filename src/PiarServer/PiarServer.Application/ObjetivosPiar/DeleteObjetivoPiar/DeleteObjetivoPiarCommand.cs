using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.ObjetivosPiar.DeleteObjetivoPiar;

public sealed record DeleteObjetivoPiarCommand(Guid Id) : ICommand<Guid>;