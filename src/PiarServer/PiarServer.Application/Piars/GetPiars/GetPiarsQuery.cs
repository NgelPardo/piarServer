using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.GetPiars;
public sealed record GetPiarsQuery() : IQuery<IReadOnlyList<PiarsResponse>>;