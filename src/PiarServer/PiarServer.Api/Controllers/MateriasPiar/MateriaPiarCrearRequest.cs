namespace PiarServer.Api.Controllers.MateriasPiar;

public sealed record MateriaPiarCrearRequest(
    Guid id_piar,
    Guid id_mat,
    string sem_mat
);

public sealed record MateriaPiarCrearBatchRequest(
    List<MateriaPiarCrearRequest> MateriasPiar
);