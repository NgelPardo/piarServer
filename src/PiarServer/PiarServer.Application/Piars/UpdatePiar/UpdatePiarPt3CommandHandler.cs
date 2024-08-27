using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Piars;

namespace PiarServer.Application.Piars.UpdatePiar;

internal class UpdatePiarPt3CommandHandler : ICommandHandler<UpdatePiarPt3Command, Guid>
{
    private readonly IPiarRepository _piarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePiarPt3CommandHandler(IPiarRepository piarRepository, IUnitOfWork unitOfWork)
    {
        _piarRepository = piarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdatePiarPt3Command request, CancellationToken cancellationToken)
    {
        var piar = await _piarRepository.GetByIdAsync(request.Id);

        if (piar is null)
        {
            return Result.Failure<Guid>(PiarErrors.NotFound);
        }

        var recomendaciones = new Recomendaciones(
            request.AccFam,
            request.EstrFam,
            request.AccDoc,
            request.EstrDoc,
            request.AccDir,
            request.EstrDir,
            request.AccAdm,
            request.EstrAdm,
            request.AccPar,
            request.EstrPar
        );

        piar.UpdatePt3( recomendaciones );

        await _piarRepository.UpdatePt3( piar, cancellationToken );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return piar.Id!;
    }
}
