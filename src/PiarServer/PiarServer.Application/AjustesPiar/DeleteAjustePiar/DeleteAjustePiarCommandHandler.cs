using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Ajustes;
using PiarServer.Domain.AjustesPiar;

namespace PiarServer.Application.AjustesPiar.DeleteAjustePiar;

internal sealed class DeleteAjustePiarCommandHandler : ICommandHandler<DeleteAjustePiarCommand, Guid>
{
    private readonly IAjustePiarRepository _ajustePiarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAjustePiarCommandHandler(IAjustePiarRepository ajustePiarRepository, IUnitOfWork unitOfWork)
    {
        _ajustePiarRepository = ajustePiarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteAjustePiarCommand request, CancellationToken cancellationToken)
    {
        var ajustePiar = await _ajustePiarRepository.GetByIdAsync(request.Id);

        if(ajustePiar is null)
        {
            return Result.Failure<Guid>(AjusteErrors.NotFound);
        }

        _ajustePiarRepository.Remove(ajustePiar);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(ajustePiar.Id);
    }
}
    
