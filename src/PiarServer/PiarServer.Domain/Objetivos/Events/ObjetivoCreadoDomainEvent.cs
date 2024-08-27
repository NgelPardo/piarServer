using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Objetivos.Events;

public sealed record ObjetivoCreadoDomainEvent(Guid IdObj) : IDomainEvent;
