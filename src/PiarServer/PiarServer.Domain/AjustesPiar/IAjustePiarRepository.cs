namespace PiarServer.Domain.AjustesPiar;

public interface IAjustePiarRepository
{
    Task<AjustePiar?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(AjustePiar ajustePiar);
    void Remove(AjustePiar ajustePiar);
}