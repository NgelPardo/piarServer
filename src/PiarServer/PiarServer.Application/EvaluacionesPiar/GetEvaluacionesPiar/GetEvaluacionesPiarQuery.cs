using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.EvaluacionesPiar.GetEvaluacionesPiar;

public sealed record GetEvaluacionesPiarQuery(Guid Id) : IQuery<IReadOnlyList<EvaluacionPiarResponse>>;