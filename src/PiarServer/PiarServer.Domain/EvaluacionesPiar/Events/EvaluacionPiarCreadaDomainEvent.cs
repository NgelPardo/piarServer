using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.EvaluacionesPiar.Events;

public sealed record  EvaluacionPiarCreadaDomainEvent(Guid IdEva) : IDomainEvent;