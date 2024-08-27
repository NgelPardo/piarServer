using PiarServer.Domain.Objetivos;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class ObjetivoRepository : Repository<Objetivo>, IObjetivoRepository
{
    public ObjetivoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Update(Objetivo objetivo, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Objetivo>().Update(objetivo);
        await Task.CompletedTask;
    }
}