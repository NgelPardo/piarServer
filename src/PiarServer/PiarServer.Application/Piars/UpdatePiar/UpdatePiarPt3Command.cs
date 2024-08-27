using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.UpdatePiar;

public record UpdatePiarPt3Command(
    Guid Id,
    string AccFam,
    string EstrFam,
    string AccDoc,
    string EstrDoc,
    string AccDir,
    string EstrDir,
    string AccAdm,
    string EstrAdm,
    string AccPar,
    string EstrPar
) : ICommand<Guid>;