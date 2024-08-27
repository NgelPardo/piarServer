namespace PiarServer.Domain.Barreras;

public interface IBarreraRepository
{
    Task<Barrera?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Barrera barrera);
    void Remove(Barrera barrera);
    Task Update(Barrera barrera, CancellationToken cancellationToken = default);
}