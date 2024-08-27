namespace PiarServer.Application.AjustesPiar.GetAjustesPiar;

public sealed class AjustePiarResponse
{
    public Guid id { get; init; }
    public Guid id_mat { get; init; }
    public Guid id_ajt { get; init; }
    public Guid id_piar { get; init; }
    public string? desc_ajt { get; init; }
    public string? sem_ajt { get; init; }
}