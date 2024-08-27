using PiarServer.Domain.Barreras;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class BarreraRepository : Repository<Barrera>, IBarreraRepository
{
    public BarreraRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Update(Barrera barrera, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Barrera>().Update(barrera);
        await Task.CompletedTask;
    }
}