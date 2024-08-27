using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Barreras;

namespace PiarServer.Application.Barreras.UpdateBarrera;

internal class UpdateBarreraCommandHandler : ICommandHandler<UpdateBarreraCommand, Guid>
{
    private readonly IBarreraRepository _barreraRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBarreraCommandHandler(IBarreraRepository barreraRepository, IUnitOfWork unitOfWork)
    {
        _barreraRepository = barreraRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateBarreraCommand request, CancellationToken cancellationToken)
    {
        var barrera = await _barreraRepository.GetByIdAsync(request.Id);

        if ( barrera is null )
        {
            return Result.Failure<Guid>(BarreraErrors.NotFound);
        }

        barrera.Update(
            new Informacion(request.DescBarr!)
        );

        await _barreraRepository.Update(barrera, cancellationToken);

        await _unitOfWork.SaveChangesAsync();

        return barrera.Id!;
    }
}
