namespace PiarServer.Application.Materias.GetMaterias;

public sealed class MateriaResponse
{
    public Guid id {get; init;}
    public string? nom_mat { get; init; }
    public string? grd_mat { get; init; }
    public Guid id_prof {get; init;}
    public Guid id_uss {get; init;}
    public DateTime? fec_dil {get; init;}
}