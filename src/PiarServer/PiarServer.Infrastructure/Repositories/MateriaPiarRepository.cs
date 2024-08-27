using PiarServer.Domain.MateriasPiar;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class MateriaPiarRepository : Repository<MateriaPiar>, IMateriaPiarRepository
{
    public MateriaPiarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}