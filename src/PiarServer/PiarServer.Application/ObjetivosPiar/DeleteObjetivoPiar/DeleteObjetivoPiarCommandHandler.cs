using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Objetivos;
using PiarServer.Domain.ObjetivosPiar;

namespace PiarServer.Application.ObjetivosPiar.DeleteObjetivoPiar;

internal sealed class DeleteObjetivoPiarCommandHandler : ICommandHandler<DeleteObjetivoPiarCommand, Guid>
{
    private readonly IObjetivoPiarRepository _objetivoPiarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteObjetivoPiarCommandHandler(IObjetivoPiarRepository objetivoPiarRepository, IUnitOfWork unitOfWork)
    {
        _objetivoPiarRepository = objetivoPiarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteObjetivoPiarCommand request, CancellationToken cancellationToken)
    {
        var objetivoPiar = await _objetivoPiarRepository.GetByIdAsync(request.Id);

        if( objetivoPiar is null )
        {
            return Result.Failure<Guid>(ObjetivoErrors.NotFound);
        }

        _objetivoPiarRepository.Remove(objetivoPiar);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(objetivoPiar.Id);
    }
}
