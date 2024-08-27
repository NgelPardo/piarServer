using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Objetivos.CrearObjetivo;

public record CrearObjetivoCommand(
    Guid IdMat,
    string DescObj,
    Guid IdUss,
    DateTime FecDil
) : ICommand<Guid>;