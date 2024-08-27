using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Barreras.GetBarreras;

public sealed record GetBarrerasQuery(Guid Id) : IQuery<IReadOnlyList<BarreraResponse>>;