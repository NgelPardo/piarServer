namespace PiarServer.Application.Objetivos.CrearObjetivo;

public sealed record CrearObjetivoRequest(
    Guid id_mat,
    string desc_obj,
    Guid id_uss,
    DateTime fec_dil
);