using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.BarrerasPiar.GetBarrerasPiar;

public sealed record GetBarrerasPiarQuery(Guid Id) : IQuery<IReadOnlyList<BarreraPiarResponse>>;