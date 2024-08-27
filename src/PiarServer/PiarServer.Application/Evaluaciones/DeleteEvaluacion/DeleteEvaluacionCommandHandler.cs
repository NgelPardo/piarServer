using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Evaluaciones;

namespace PiarServer.Application.Evaluaciones.DeleteEvaluacion;

internal sealed class DeleteEvaluacionCommandHandler : ICommandHandler<DeleteEvaluacionCommand, Guid>
{
    private readonly IEvaluacionRepository _evalacionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEvaluacionCommandHandler(IEvaluacionRepository evalacionRepository, IUnitOfWork unitOfWork)
    {
        _evalacionRepository = evalacionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteEvaluacionCommand request, CancellationToken cancellationToken)
    {
        var evaluacion = await _evalacionRepository.GetByIdAsync(request.Id);
    
        if (evaluacion is null)
        {
            return Result.Failure<Guid>(EvaluacionErrors.NotFound);
        }

        _evalacionRepository.Remove(evaluacion);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(evaluacion.Id);
    }
}
