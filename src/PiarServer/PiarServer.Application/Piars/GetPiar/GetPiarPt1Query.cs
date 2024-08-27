using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.GetPiar;

public sealed record GetPiarPt1Query(Guid PiarId) : IQuery<PiarPt1Response>;