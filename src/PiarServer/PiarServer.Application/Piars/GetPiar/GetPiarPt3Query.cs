using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.GetPiar;

public sealed record GetPiarPt3Query(Guid PiarId) : IQuery<PiarPt3Response>;