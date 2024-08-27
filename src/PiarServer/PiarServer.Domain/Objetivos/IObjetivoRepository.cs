namespace PiarServer.Domain.Objetivos;

public interface IObjetivoRepository
{
    Task<Objetivo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Objetivo objetivo);
    void Remove(Objetivo objetivo);
    Task Update(Objetivo objetivo, CancellationToken cancellationToken = default);
}