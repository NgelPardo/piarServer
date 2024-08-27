namespace PiarServer.Domain.Evaluaciones;

public interface IEvaluacionRepository
{
    Task<Evaluacion?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Evaluacion evaluacion);
    void Remove(Evaluacion evaluacion);
    Task Update(Evaluacion evaluacion, CancellationToken cancellationToken = default);
}