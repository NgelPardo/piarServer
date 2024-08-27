namespace PiarServer.Domain.EvaluacionesPiar;

public interface IEvaluacionPiarRepository
{
    Task<EvaluacionPiar?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(EvaluacionPiar evaluacionPiar);
    void Remove(EvaluacionPiar evaluacionPiar);
}