using PiarServer.Application.AjustesPiar.GetAjustesPiar;
using PiarServer.Application.BarrerasPiar.GetBarrerasPiar;
using PiarServer.Application.EvaluacionesPiar.GetEvaluacionesPiar;
using PiarServer.Application.ObjetivosPiar.GetObjetivosPiar;

namespace PiarServer.Application.MateriasPiar.GetMateriasPiar;

public sealed class MateriaPiarResponse
{
    public Guid id { get; init; }
    public Guid id_piar { get; init; }
    public Guid id_mat { get; init; }
    public string? sem_mat { get; init; }
    public string? nom_mat { get; init; }
    public List<ObjetivoPiarResponse>? objetivos { get; set; }
    public List<BarreraPiarResponse>? barreras { get; set; }
    public List<AjustePiarResponse>? ajustes { get; set; }
    public List<EvaluacionPiarResponse>? evaluaciones { get; set; }
}