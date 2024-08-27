using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Ajustes.UpdateAjuste;

public record UpdateAjusteCommand(
    Guid Id,
    string? DescAjt
) : ICommand<Guid>;