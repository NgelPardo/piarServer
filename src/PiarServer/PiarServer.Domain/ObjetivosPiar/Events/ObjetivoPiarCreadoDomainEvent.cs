using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.ObjetivosPiar.Events;

public sealed record ObjetivoPiarCreadoDomainEvent(Guid IdObj) : IDomainEvent;