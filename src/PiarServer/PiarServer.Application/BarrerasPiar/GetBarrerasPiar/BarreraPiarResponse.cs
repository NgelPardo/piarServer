namespace PiarServer.Application.BarrerasPiar.GetBarrerasPiar;

public sealed class BarreraPiarResponse
{
    public Guid id { get; init; }
    public Guid id_mat { get; init; }
    public Guid id_barr { get; init; }
    public Guid id_piar { get; init; }
    public string? desc_barr { get; init; }
    public string? sem_barr { get; init; }
}
