using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.MateriasPiar.DeleteMateriaPiar;

public sealed record DeleteMateriaPiarCommand(Guid Id) : ICommand<Guid>;