namespace PiarServer.Domain.ObjetivosPiar;

public interface IObjetivoPiarRepository
{
    Task<ObjetivoPiar?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(ObjetivoPiar objetivoPiar);
    void Remove(ObjetivoPiar objetivoPiar);
}