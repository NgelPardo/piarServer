using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Objetivos;

public static class ObjetivoErrors
{
    public static Error NotFound = new Error(
        "Objetivo.Found",
        "No existe el objetivo buscado por este id"
    );
    public static Error Overlap = new Error(
        "Objetivo.Overlap",
        "El objetivo esta siendo tomado por 2 o mas usuarios al mismo tiempo"
    );
}