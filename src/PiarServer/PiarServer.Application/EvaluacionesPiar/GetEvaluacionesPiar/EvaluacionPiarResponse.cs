namespace PiarServer.Application.EvaluacionesPiar.GetEvaluacionesPiar;

public sealed class EvaluacionPiarResponse
{
    public Guid id { get; init; }
    public Guid id_mat { get; init; }
    public Guid id_eva { get; init; }
    public Guid id_piar { get; init; }
    public string? desc_eva { get; init; }
    public string? sem_eva { get; init; }
}