namespace PiarServer.Application.Ajustes.GetAjustes;

public sealed class AjusteResponse
{
    public Guid id { get; init; }
    public Guid id_mat { get; init; }
    public string? desc_ajt { get; init; }
    public DateTime fec_dil { get; init; }
}