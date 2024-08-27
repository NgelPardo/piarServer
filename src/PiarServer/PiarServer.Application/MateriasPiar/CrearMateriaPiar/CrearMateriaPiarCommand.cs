using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.MateriasPiar.CrearMateriaPiar;

public record CrearMateriaPiarCommand(
    Guid IdPiar,
    Guid IdMat,
    string SemMat
) : ICommand<Guid>;