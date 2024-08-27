using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Barreras.Events;

public sealed record BarreraCreadaDomainEvent(Guid IdBarr) : IDomainEvent;