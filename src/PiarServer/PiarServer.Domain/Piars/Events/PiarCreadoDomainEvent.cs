using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Piars.Events;

public sealed record PiarCreadoDomainEvent(Guid PiarId) : IDomainEvent;