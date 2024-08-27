namespace PiarServer.Domain.FirmasPiar;

public interface IFirmaPiarRepository
{
    Task<FirmaPiar?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(FirmaPiar firmaPiar);
}