using PiarServer.Domain.EvaluacionesPiar;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class EvaluacionPiarRepository : Repository<EvaluacionPiar>, IEvaluacionPiarRepository
{
    public EvaluacionPiarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}