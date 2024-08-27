using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Ajustes.DeleteAjuste;

public sealed record DeleteAjusteCommand(Guid Id) : ICommand<Guid>;