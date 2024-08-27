using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Evaluaciones.UpdateEvaluacion;

public record UpdateEvaluacionCommand(
    Guid Id,
    string? DescEva
) : ICommand<Guid>;