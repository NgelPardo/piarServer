using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Ajustes;

namespace PiarServer.Application.Ajustes.DeleteAjuste;

internal sealed class DeleteAjusteCommandHandler : ICommandHandler<DeleteAjusteCommand, Guid>
{
    private readonly IAjusteRepository _ajusteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAjusteCommandHandler(IAjusteRepository ajusteRepository, IUnitOfWork unitOfWork)
    {
        _ajusteRepository = ajusteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteAjusteCommand request, CancellationToken cancellationToken)
    {
        var ajuste = await _ajusteRepository.GetByIdAsync(request.Id);
    
        if (ajuste is null)
        {
            return Result.Failure<Guid>(AjusteErrors.NotFound);
        }

        _ajusteRepository.Remove(ajuste);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(ajuste.Id);
    }
}
