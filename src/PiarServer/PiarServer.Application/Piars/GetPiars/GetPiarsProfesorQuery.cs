using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.GetPiars;

public sealed record GetPiarsProfesorQuery(Guid Id) : IQuery<IReadOnlyList<PiarsResponse>>; 