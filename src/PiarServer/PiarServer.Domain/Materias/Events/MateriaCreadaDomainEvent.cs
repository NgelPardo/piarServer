using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Materias.Events;

public sealed record MateriaCreadaDomainEvent(Guid IdMat) : IDomainEvent;