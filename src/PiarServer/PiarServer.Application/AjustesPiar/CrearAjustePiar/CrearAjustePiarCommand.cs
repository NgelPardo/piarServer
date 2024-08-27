using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.AjustesPiar.CrearAjustePiar;

public record CrearAjustePiarCommand(
    Guid IdMat,
    Guid IdAjt,
    Guid IdPiar,
    string SemAjt
) : ICommand<Guid>;