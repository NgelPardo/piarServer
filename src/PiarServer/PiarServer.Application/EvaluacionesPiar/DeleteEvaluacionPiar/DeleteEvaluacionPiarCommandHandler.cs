using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Evaluaciones;
using PiarServer.Domain.EvaluacionesPiar;

namespace PiarServer.Application.EvaluacionesPiar.DeleteEvaluacionPiar;

internal sealed class DeleteEvaluacionPiarCommandHandler : ICommandHandler<DeleteEvaluacionPiarCommand, Guid>
{
    private readonly IEvaluacionPiarRepository _evalacionPiarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEvaluacionPiarCommandHandler(IEvaluacionPiarRepository evalacionPiarRepository, IUnitOfWork unitOfWork)
    {
        _evalacionPiarRepository = evalacionPiarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteEvaluacionPiarCommand request, CancellationToken cancellationToken)
    {
        var evaluacionPiar = await _evalacionPiarRepository.GetByIdAsync(request.Id);

        if(evaluacionPiar is null)
        {
            return Result.Failure<Guid>(EvaluacionErrors.NotFound);
        }

        _evalacionPiarRepository.Remove(evaluacionPiar);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(evaluacionPiar.Id);
    }
}
