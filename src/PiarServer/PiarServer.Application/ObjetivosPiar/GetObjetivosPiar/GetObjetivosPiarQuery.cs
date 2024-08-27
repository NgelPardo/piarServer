using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.ObjetivosPiar.GetObjetivosPiar;

public sealed record GetObjetivosPiarQuery(Guid Id) : IQuery<IReadOnlyList<ObjetivoPiarResponse>>;