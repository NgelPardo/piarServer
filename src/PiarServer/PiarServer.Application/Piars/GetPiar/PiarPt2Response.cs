namespace PiarServer.Application.Piars.GetPiar;

public sealed class PiarPt2Response
{
    public Guid id { get; init; }
    public DateTime fec_dig_a2 { get; init; }
    public string? inst_edu_a2 { get; init; }
    public string? sed_a2 { get; init; }
    public string? jor_a2 { get; init; }
    public string? docs_ela { get; init; }
    public string? grd_est { get; init; }
    public string? desc_1_est { get; init; }
    public string? desc_2_est { get; init; }
}