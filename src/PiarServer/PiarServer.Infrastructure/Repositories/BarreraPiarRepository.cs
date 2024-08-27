using PiarServer.Domain.BarrerasPiar;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class BarreraPiarRepository : Repository<BarreraPiar>, IBarreraPiarRepository
{
    public BarreraPiarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}