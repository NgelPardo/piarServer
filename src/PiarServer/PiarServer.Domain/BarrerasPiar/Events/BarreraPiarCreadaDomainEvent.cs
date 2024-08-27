using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.BarrerasPiar.Events;

public sealed record BarreraPiarCreadaDomainEvent(Guid IdBarr) : IDomainEvent;