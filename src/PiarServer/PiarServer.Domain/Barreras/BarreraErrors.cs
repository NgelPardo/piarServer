using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Barreras;

public static class BarreraErrors
{
    public static Error NotFound = new Error(
        "Barrera.Found",
        "No existe la barrera buscada por este id"
    );
    public static Error Overlap = new Error(
        "Barrera.Overlap",
        "La barrera esta siendo tomado por 2 o mas usuarios al mismo tiempo"
    );
}