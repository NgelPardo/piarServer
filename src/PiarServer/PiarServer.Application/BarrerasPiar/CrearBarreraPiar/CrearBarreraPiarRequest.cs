namespace PiarServer.Application.BarrerasPiar.CrearBarreraPiar;

public sealed record CrearBarreraPiarRequest(
    Guid id_mat,
    Guid id_barr,
    Guid id_piar,
    string sem_barr
);

public sealed record CrearBarreraPiarBatchRequest(
    List<CrearBarreraPiarRequest> BarrerasPiar
);