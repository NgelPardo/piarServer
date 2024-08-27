using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.MateriasPiar.Events;

public sealed record MateriaPiarCreadaDomainEvent(Guid IdMat) : IDomainEvent;