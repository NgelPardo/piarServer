namespace PiarServer.Application.Piars.GetPiar;

public sealed class PiarPt3Response
{
    public Guid id { get; init; }
    public string? acc_fam { get; init; }
    public string? estr_fam { get; init; }
    public string? acc_doc { get; init; }
    public string? estr_doc { get; init; }
    public string? acc_dir { get; init; }
    public string? estr_dir { get; init; }
    public string? acc_adm { get; init; }
    public string? estr_adm { get; init; }
    public string? acc_par { get; init; }
    public string? estr_par { get; init; }
}