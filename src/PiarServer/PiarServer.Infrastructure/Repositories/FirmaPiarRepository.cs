using PiarServer.Domain.FirmasPiar;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class FirmaPiarRepository : Repository<FirmaPiar>, IFirmaPiarRepository
{
    public FirmaPiarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}