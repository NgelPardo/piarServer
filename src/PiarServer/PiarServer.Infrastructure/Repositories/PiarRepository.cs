using PiarServer.Domain.Piars;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class PiarRepository : Repository<Piar>, IPiarRepository
{
    public PiarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task UpdatePt1(Piar piar, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Piar>().Update(piar);
        await Task.CompletedTask;
    }
    public async Task UpdatePt2(Piar piar, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Piar>().Update(piar);
        await Task.CompletedTask;
    }

    public async Task UpdatePt3(Piar piar, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Piar>().Update(piar);
        await Task.CompletedTask;
    }

    public async Task UpdatePt4(Piar piar, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Piar>().Update(piar);
        await Task.CompletedTask;
    }

}