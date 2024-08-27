namespace PiarServer.Domain.Ajustes;

public interface IAjusteRepository
{
    Task<Ajuste?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Ajuste ajuste);
    void Remove(Ajuste ajuste);
    Task Update(Ajuste ajuste, CancellationToken cancellationToken = default);
}