using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Ajustes.Events;

public sealed record AjusteCreadoDomainEvent(Guid IdAjt) : IDomainEvent;