using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Ajustes.CrearAjuste;

public record CrearAjusteCommand(
    Guid IdMat,
    string DescAjt,
    Guid IdUss,
    DateTime FecDil
) : ICommand<Guid>;