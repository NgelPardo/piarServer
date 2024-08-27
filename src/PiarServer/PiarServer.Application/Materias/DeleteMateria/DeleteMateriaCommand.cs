using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Materias.DeleteMateria;

public sealed record DeleteMateriaCommand(Guid Id) : ICommand<Guid>;