using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.GetPiar;

public sealed record GetPiarPt4Query(Guid PiarId) : IQuery<PiarPt4Response>;