using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Barreras;
using PiarServer.Domain.BarrerasPiar;

namespace PiarServer.Application.BarrerasPiar.DeleteBarreraPiar;

internal sealed class DeleteBarreraPiarCommandHandler : ICommandHandler<DeleteBarreraPiarCommand, Guid>
{
    private readonly IBarreraPiarRepository _barreraPiarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBarreraPiarCommandHandler(IBarreraPiarRepository barreraPiarRepository, IUnitOfWork unitOfWork)
    {
        _barreraPiarRepository = barreraPiarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteBarreraPiarCommand request, CancellationToken cancellationToken)
    {
        var barreraPiar = await _barreraPiarRepository.GetByIdAsync(request.Id);

        if(barreraPiar is null)
        {
            return Result.Failure<Guid>(BarreraErrors.NotFound);
        }

        _barreraPiarRepository.Remove(barreraPiar);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(barreraPiar.Id);
    }
}
