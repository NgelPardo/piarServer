using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Objetivos.GetObjetivos;

public sealed record GetObjetivosQuery(Guid Id) : IQuery<IReadOnlyList<ObjetivoResponse>>;