using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Barreras.CrearBarrera;

public record CrearBarreraCommand(
    Guid IdMat,
    string DescBarr,
    Guid IdUss,
    DateTime FecDil
) : ICommand<Guid>;