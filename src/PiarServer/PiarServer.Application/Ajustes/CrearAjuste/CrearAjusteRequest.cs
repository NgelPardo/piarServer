namespace PiarServer.Application.Ajustes.CrearAjuste;

public sealed record CrearAjusteRequest(
    Guid id_mat,
    string desc_ajt,
    Guid id_uss,
    DateTime fec_dil
);