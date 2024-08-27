using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Evaluaciones;

namespace PiarServer.Application.Evaluaciones.UpdateEvaluacion;

internal class UpdateEvaluacionCommandHandler : ICommandHandler<UpdateEvaluacionCommand, Guid>
{
    private readonly IEvaluacionRepository _evalucionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEvaluacionCommandHandler(IEvaluacionRepository evalacionRepository, IUnitOfWork unitOfWork)
    {
        _evalucionRepository = evalacionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateEvaluacionCommand request, CancellationToken cancellationToken)
    {
        var evaluacion = await _evalucionRepository.GetByIdAsync(request.Id);
    
        if ( evaluacion is null )
        {
            return Result.Failure<Guid>(EvaluacionErrors.NotFound);
        }

        evaluacion.Update(
            new Informacion(request.DescEva!)
        );

        await _evalucionRepository.Update(evaluacion, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return evaluacion.Id!;
    }
}
