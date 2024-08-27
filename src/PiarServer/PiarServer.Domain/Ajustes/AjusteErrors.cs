using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Ajustes;

public static class AjusteErrors
{
    public static Error NotFound = new Error(
        "Ajuste.Found",
        "No existe el ajuste buscado por este id"
    );
    public static Error Overlap = new Error(
        "Ajuste.Overlap",
        "El ajuste esta siendo tomado por 2 o mas usuarios al mismo tiempo"
    );
}