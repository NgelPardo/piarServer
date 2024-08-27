using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Objetivos;

namespace PiarServer.Application.Objetivos.UpdateObjetivo;

internal class UpdateObjetivoCommandHandler : ICommandHandler<UpdateObjetivoCommand, Guid>
{
    private readonly IObjetivoRepository _objetivoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateObjetivoCommandHandler(IObjetivoRepository objetivoRepository, IUnitOfWork unitOfWork)
    {
        _objetivoRepository = objetivoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateObjetivoCommand request, CancellationToken cancellationToken)
    {
        var objetivo = await _objetivoRepository.GetByIdAsync(request.Id);

        if ( objetivo is null )
        {
            return Result.Failure<Guid>(ObjetivoErrors.NotFound);
        }

        objetivo.Update(
            new Informacion(request.DescObj!)
        );

        await _objetivoRepository.Update(objetivo, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return objetivo.Id!;
    }
}
