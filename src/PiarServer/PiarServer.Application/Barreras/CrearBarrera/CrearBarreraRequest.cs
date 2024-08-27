namespace PiarServer.Application.Barreras.CrearBarrera;

public sealed record CrearBarreraRequest(
    Guid id_mat,
    string desc_barr,
    Guid id_uss,
    DateTime fec_dil
);