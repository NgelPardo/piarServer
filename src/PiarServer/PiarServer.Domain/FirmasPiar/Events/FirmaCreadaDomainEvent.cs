using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.FirmasPiar.Events;

public sealed record FirmaCreadaDomainEvent(Guid IdFir) : IDomainEvent;