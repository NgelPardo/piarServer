using PiarServer.Domain.AjustesPiar;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class AjustePiarRepository : Repository<AjustePiar>, IAjustePiarRepository
{
    public AjustePiarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}