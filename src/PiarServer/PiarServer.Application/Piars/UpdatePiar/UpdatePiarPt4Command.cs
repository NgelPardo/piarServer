using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.UpdatePiar;

public record UpdatePiarPt4Command(
    Guid Id,
    DateTime FecDilA3,
    string ActsApo,
    string DocDir,
    string InstEduA3,
    string NomFam,
    string Compromisos
) : ICommand<Guid>;