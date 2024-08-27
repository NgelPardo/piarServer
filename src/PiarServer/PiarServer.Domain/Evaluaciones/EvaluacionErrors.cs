using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Evaluaciones;

public static class EvaluacionErrors
{
    public static Error NotFound = new Error(
        "Evaluacion.Found",
        "No existe la evaluacion buscado por este id"
    );
    public static Error Overlap = new Error(
        "Evaluacion.Overlap",
        "La evaluacion esta siendo tomado por 2 o mas usuarios al mismo tiempo"
    );
}