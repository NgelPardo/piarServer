using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Barreras.UpdateBarrera;

public record UpdateBarreraCommand(
    Guid Id,
    string? DescBarr
) : ICommand<Guid>;