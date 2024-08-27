using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.GetPiar;

public sealed record GetPiarQuery(Guid PiarId) : IQuery<PiarResponse>;
