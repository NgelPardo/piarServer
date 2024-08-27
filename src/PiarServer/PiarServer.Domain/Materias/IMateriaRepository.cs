namespace PiarServer.Domain.Materias;

public interface IMateriaRepository
{
    Task<Materia?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Materia materia);
    void Remove(Materia materia);
    Task Update(Materia materia, CancellationToken cancellationToken = default);
}