namespace PiarServer.Application.Evaluaciones.GetEvaluaciones;

public sealed class EvaluacionResponse
{
    public Guid id { get; init; }
    public Guid id_mat { get; init; }
    public string? desc_eva { get; init; }
    public DateTime fec_dil { get; init; }
}