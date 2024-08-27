namespace PiarServer.Application.Piars.GetPiar;

public sealed class PiarPt4Response
{
    public Guid id { get; init; }
    public DateTime fec_dil_a3 { get; init;}
    public string? acts_apo { get; init;}
    public string? doc_dir { get; init;}
    public string? inst_edu_a3 { get; init;}
    public string? nom_fam { get; init;}
    public string? compromisos { get; init;}
}