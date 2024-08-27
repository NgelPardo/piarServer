namespace PiarServer.Application.Objetivos.GetObjetivos;

public sealed class ObjetivoResponse
{
    public Guid id { get; init; }
    public Guid id_mat {get; init;}
    public string? desc_obj {get; init;}
    public DateTime fec_dil {get; init;}
}