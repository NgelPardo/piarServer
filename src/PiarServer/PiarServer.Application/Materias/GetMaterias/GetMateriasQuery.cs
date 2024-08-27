using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Materias.GetMaterias;
public sealed record GetMateriasQuery(Guid Id) : IQuery<IReadOnlyList<MateriaResponse>>;