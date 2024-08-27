using PiarServer.Domain.Ajustes;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class AjusteRepository : Repository<Ajuste>, IAjusteRepository
{
    public AjusteRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    public async Task Update(Ajuste ajuste, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Ajuste>().Update(ajuste);
        await Task.CompletedTask;
    }
}