using PiarServer.Domain.ObjetivosPiar;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class ObjetivoPiarRepository : Repository<ObjetivoPiar>, IObjetivoPiarRepository
{
    public ObjetivoPiarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}