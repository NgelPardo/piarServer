namespace PiarServer.Domain.BarrerasPiar;

public interface IBarreraPiarRepository
{
    Task<BarreraPiar?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(BarreraPiar barreraPiar);
    void Remove(BarreraPiar barreraPiar);
}