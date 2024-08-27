using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Ajustes;

namespace PiarServer.Application.Ajustes.UpdateAjuste;

internal class UpdateAjusteCommandHandler : ICommandHandler<UpdateAjusteCommand, Guid>
{
    private readonly IAjusteRepository _ajusteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAjusteCommandHandler(IAjusteRepository ajusteRepository, IUnitOfWork unitOfWork)
    {
        _ajusteRepository = ajusteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateAjusteCommand request, CancellationToken cancellationToken)
    {
        var barrera = await _ajusteRepository.GetByIdAsync(request.Id);

        if ( barrera is null )
        {
            return Result.Failure<Guid>(AjusteErrors.NotFound);
        }

        barrera.Update(
            new Informacion(request.DescAjt!)
        );

        await _ajusteRepository.Update(barrera, cancellationToken);

        await _unitOfWork.SaveChangesAsync();

        return barrera.Id!;
    }
}
