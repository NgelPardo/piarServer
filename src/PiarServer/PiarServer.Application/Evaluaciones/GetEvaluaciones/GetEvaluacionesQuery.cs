using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Evaluaciones.GetEvaluaciones;

public sealed record GetEvaluacionesQuery(Guid Id) : IQuery<IReadOnlyList<EvaluacionResponse>>;