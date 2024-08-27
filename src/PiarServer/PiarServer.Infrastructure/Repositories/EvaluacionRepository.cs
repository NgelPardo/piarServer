using PiarServer.Domain.Evaluaciones;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class EvaluacionRepository : Repository<Evaluacion>, IEvaluacionRepository
{
    public EvaluacionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    public async Task Update(Evaluacion evaluacion, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Evaluacion>().Update(evaluacion);
        await Task.CompletedTask;
    }
}