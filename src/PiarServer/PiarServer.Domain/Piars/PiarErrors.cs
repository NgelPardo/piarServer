using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Piars;

public static class PiarErrors
{
    public static Error NotFound = new(
        "Piar.Found",
        "El piar con el Id especificado no fue encontrado"
    );

    public static Error Overlap = new(
        "Piar.Overlap",
        "El piar esta siendo tomado por 2 o mas usuarios al mismo tiempo"
    );

}