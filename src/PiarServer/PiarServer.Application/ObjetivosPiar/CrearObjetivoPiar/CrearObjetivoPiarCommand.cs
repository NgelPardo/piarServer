using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.ObjetivosPiar.CrearObjetivoPiar;

public record CrearObjetivoPiarCommand(
    Guid IdMat,
    Guid IdObj,
    Guid IdPiar,
    string SemObj
) : ICommand<Guid>;