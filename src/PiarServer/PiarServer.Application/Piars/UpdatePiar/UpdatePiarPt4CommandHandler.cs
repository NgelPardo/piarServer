using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Piars;

namespace PiarServer.Application.Piars.UpdatePiar;

internal class UpdatePiarPt4CommandHandler : ICommandHandler<UpdatePiarPt4Command, Guid>
{
    private readonly IPiarRepository _piarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePiarPt4CommandHandler(IPiarRepository piarRepository, IUnitOfWork unitOfWork)
    {
        _piarRepository = piarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdatePiarPt4Command request, CancellationToken cancellationToken)
    {
        var piar = await _piarRepository.GetByIdAsync(request.Id);

        if(piar is null)
        {
            return Result.Failure<Guid>(PiarErrors.NotFound);
        }

        var diligenciamientoTres = new DiligenciamientoTres(
            request.FecDilA3,
            request.InstEduA3,
            request.DocDir,
            request.NomFam,
            request.ActsApo,
            request.Compromisos
        );

        piar.UpdatePt4( diligenciamientoTres );

        await _piarRepository.UpdatePt4( piar, cancellationToken );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return piar.Id!;
    }
}
