using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Materias.CrearMateria;

public record CrearMateriaCommand(
    Guid IdUss,
    Guid IdProf,
    string NomMat,
    string GrdMat,
    DateTime FecDil
) : ICommand<Guid>;