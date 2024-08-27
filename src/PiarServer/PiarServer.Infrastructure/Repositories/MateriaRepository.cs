using PiarServer.Domain.Materias;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class MateriaRepository : Repository<Materia>, IMateriaRepository
{
    public MateriaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Update(Materia materia, CancellationToken cancellationToken = default)
    {
        DbContext.Set<Materia>().Update(materia);
        await Task.CompletedTask;
    }
}