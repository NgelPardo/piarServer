namespace PiarServer.Application.AjustesPiar.CrearAjustePiar;

public sealed record CrearAjustePiarRequest(
    Guid id_mat,
    Guid id_ajt,
    Guid id_piar,
    string sem_ajt
);

public sealed record CrearAjustePiarBatchRequest(
    List<CrearAjustePiarRequest> AjustesPiar
);