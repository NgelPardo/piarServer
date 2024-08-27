namespace PiarServer.Application.Barreras.GetBarreras;

public sealed class BarreraResponse
{
    public Guid id { get; init; }
    public Guid id_mat { get; init; }
    public string? desc_barr { get; init; }
    public DateTime fec_dil { get; init; }
}