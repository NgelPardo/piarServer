namespace PiarServer.Api.Controllers.Materias;

public sealed record MateriaCrearRequest(
    Guid id_uss,
    Guid id_prof,
    string nom_mat,
    string grd_mat,
    DateTime fec_dil
);