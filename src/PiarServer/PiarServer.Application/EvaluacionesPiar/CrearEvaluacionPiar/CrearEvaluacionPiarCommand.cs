using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.EvaluacionesPiar.CrearEvaluacionPiar;

public record CrearEvaluacionPiarCommand(
    Guid IdMat,
    Guid IdEva,
    Guid IdPiar,
    string SemEva
) : ICommand<Guid>;