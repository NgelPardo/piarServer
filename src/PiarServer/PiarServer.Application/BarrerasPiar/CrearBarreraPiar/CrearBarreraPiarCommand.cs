using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.BarrerasPiar.CrearBarreraPiar;

public record CrearBarreraPiarCommand(
    Guid IdMat,
    Guid IdBarr,
    Guid IdPiar,
    string SemAjt
) : ICommand<Guid>;