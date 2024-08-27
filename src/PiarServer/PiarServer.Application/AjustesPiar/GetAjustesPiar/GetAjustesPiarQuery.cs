using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.AjustesPiar.GetAjustesPiar;

public sealed record GetAjustesPiarQuery(Guid Id) : IQuery<IReadOnlyList<AjustePiarResponse>>;