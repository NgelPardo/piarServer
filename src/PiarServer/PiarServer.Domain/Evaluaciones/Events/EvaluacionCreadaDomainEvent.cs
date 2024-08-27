using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Evaluaciones.Events;

public sealed record EvaluacionCreadaDomainEvent(Guid IdEva) : IDomainEvent;
