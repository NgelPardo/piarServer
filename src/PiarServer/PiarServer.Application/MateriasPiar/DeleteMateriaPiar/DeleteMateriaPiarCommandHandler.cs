using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.MateriasPiar;

namespace PiarServer.Application.MateriasPiar.DeleteMateriaPiar;

internal sealed class DeleteMateriaPiarCommandHandler : ICommandHandler<DeleteMateriaPiarCommand, Guid>
{
    private readonly IMateriaPiarRepository _materiaPiarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMateriaPiarCommandHandler(IMateriaPiarRepository materiaPiarRepository, IUnitOfWork unitOfWork)
    {
        _materiaPiarRepository = materiaPiarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteMateriaPiarCommand request, CancellationToken cancellationToken)
    {
        var materiaPiar = await _materiaPiarRepository.GetByIdAsync( request.Id );

        if( materiaPiar is null )
        {
            return Result.Failure<Guid>(MateriaPiarErrors.NotFound);
        }

        _materiaPiarRepository.Remove(materiaPiar);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(materiaPiar.Id);
    }
}
