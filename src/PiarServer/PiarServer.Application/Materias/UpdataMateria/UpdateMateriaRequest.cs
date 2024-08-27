namespace PiarServer.Application.Materias.UpdateMateria;

public record UpdateMateriaRequest(
    Guid id,
    string? nom_mat,
    string? grd_mat,
    Guid id_prof
);