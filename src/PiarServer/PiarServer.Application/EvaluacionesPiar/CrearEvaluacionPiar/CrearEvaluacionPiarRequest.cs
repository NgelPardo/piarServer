namespace PiarServer.Application.EvaluacionesPiar.CrearEvaluacionPiar;

public sealed record CrearEvaluacionPiarRequest(
    Guid id_mat,
    Guid id_eva,
    Guid id_piar,
    string sem_eva
);

public sealed record CrearEvaluacionPiarBatchRequest(
    List<CrearEvaluacionPiarRequest> EvaluacionesPiar
);