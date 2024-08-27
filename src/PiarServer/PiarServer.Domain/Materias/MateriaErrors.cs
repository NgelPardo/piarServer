using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Materias;

public static class MateriaErrors
{
    public static Error NotFound = new Error(
        "Materia.Found",
        "No existe la materia buscada por este id"
    );
    public static Error Overlap = new Error(
        "Materia.Overlap",
        "La materia esta siendo tomada por 2 o mas usuarios al mismo tiempo"
    );

}