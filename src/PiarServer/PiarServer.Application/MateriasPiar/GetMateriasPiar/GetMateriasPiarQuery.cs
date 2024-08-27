using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.MateriasPiar.GetMateriasPiar;

public sealed record GetMateriasPiarQuery(Guid Id) : IQuery<IReadOnlyList<MateriaPiarResponse>>;
