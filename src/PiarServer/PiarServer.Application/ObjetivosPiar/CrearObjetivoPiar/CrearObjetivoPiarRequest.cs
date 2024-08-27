namespace PiarServer.Application.ObjetivosPiar.CrearObjetivoPiar;

public sealed record CrearObjetivoPiarRequest(
    Guid id_mat,
    Guid id_obj,
    Guid id_piar,
    string sem_obj
);

public sealed record CrearObjetivoPiarBatchRequest(
    List<CrearObjetivoPiarRequest> ObjetivosPiar
);