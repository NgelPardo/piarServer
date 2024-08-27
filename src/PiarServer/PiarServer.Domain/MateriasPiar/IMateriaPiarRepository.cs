namespace PiarServer.Domain.MateriasPiar;

public interface IMateriaPiarRepository
{
    Task<MateriaPiar?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(MateriaPiar materiaPiar);
    void Remove(MateriaPiar materiaPiar);
}