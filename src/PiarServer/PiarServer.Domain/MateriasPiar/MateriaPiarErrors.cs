using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.MateriasPiar;

public static class MateriaPiarErrors
{
    public static Error NotFound = new Error(
        "MateriaPiar.Found",
        "No existe la materiapiar buscada por este id"
    );
    public static Error Overlap = new Error(
        "MateriaPiar.Overlap",
        "La materia esta siendo tomada por 2 o mas usuarios al mismo tiempo"
    );
}