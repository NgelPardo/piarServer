using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.AjustesPiar.Events;

public sealed record AjustePiarCreadoDomainEvent(Guid IdAjt) : IDomainEvent;