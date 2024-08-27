namespace PiarServer.Application.Evaluaciones.UpdateEvaluacion;

public record UpdateEvaluacionRequest(
    Guid id,
    string desc_eva
);