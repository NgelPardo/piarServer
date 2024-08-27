using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Barreras;

namespace PiarServer.Application.Barreras.DeleteBarrera;

internal sealed class DeleteBarreraCommandHandler : ICommandHandler<DeleteBarreraCommand, Guid>
{
    private readonly IBarreraRepository _barreraRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBarreraCommandHandler(IBarreraRepository barreraRepository, IUnitOfWork unitOfWork)
    {
        _barreraRepository = barreraRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteBarreraCommand request, CancellationToken cancellationToken)
    {
        var barrera = await _barreraRepository.GetByIdAsync( request.Id );

        if (barrera is null)
        {
            return Result.Failure<Guid>(BarreraErrors.NotFound);
        }

        _barreraRepository.Remove(barrera);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(barrera.Id);
    }
}
