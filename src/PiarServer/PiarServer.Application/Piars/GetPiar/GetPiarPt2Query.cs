using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.GetPiar;

public sealed record GetPiarPt2Query(Guid PiarId) : IQuery<PiarPt2Response>;