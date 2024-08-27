namespace PiarServer.Application.ObjetivosPiar.GetObjetivosPiar;

public sealed class ObjetivoPiarResponse
{
    public Guid id { get; init; }
    public Guid id_mat { get; init; }
    public Guid id_obj { get; init; }
    public Guid id_piar { get; init; }
    public string? desc_obj { get; init; }
    public string? sem_obj { get; init; }
}