using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Ajustes.GetAjustes;

public sealed record GetAjustesQuery(Guid Id) : IQuery<IReadOnlyList<AjusteResponse>>;