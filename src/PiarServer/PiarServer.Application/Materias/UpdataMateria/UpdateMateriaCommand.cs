using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Materias.UpdateMateria;
public record UpdateMateriaCommand(
    Guid Id,
    string? NomMat,
    string? GrdMat,
    Guid IdProf
) : ICommand<Guid>;