namespace PiarServer.Domain.Piars;

public interface IPiarRepository
{
    Task<Piar?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Piar piar);
    Task UpdatePt1(Piar piar, CancellationToken cancellationToken = default);
    Task UpdatePt2(Piar piar, CancellationToken cancellationToken = default);
    Task UpdatePt3(Piar piar, CancellationToken cancellationToken = default);
    Task UpdatePt4(Piar piar, CancellationToken cancellationToken = default);
}