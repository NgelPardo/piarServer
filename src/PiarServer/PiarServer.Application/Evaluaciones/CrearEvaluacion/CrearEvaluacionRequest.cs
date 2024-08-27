namespace PiarServer.Application.Evaluaciones.CrearEvaluacion;

public sealed record CrearEvaluacionRequest(
    Guid id_mat,
    string desc_eva,
    Guid id_uss,
    DateTime fec_dil
);
