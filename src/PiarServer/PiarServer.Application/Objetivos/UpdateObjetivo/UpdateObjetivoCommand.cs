using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Objetivos.UpdateObjetivo;
public record UpdateObjetivoCommand(
    Guid Id,
    string? DescObj
) : ICommand<Guid>;