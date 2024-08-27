using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Objetivos;

namespace PiarServer.Application.Objetivos.DeleteObjetivo;

internal sealed class DeleteObjetivoCommandHandler : ICommandHandler<DeleteObjetivoCommand, Guid>
{
    private readonly IObjetivoRepository _objetivoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteObjetivoCommandHandler(IObjetivoRepository objetivoRepository, IUnitOfWork unitOfWork)
    {
        _objetivoRepository = objetivoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteObjetivoCommand request, CancellationToken cancellationToken)
    {
        var objetivo = await _objetivoRepository.GetByIdAsync(request.Id);

        if ( objetivo is null )
        {
            return Result.Failure<Guid>(ObjetivoErrors.NotFound);
        }

        _objetivoRepository.Remove(objetivo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(objetivo.Id);
    }
}
