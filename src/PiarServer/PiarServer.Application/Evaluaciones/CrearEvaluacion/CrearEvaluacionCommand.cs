using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Evaluaciones.CrearEvaluacion;

public record CrearEvaluacionCommand(
    Guid IdMat,
    string DescEva,
    Guid IdUss,
    DateTime FecDil
) : ICommand<Guid>;