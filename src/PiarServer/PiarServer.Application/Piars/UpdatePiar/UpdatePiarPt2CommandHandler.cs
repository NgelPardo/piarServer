using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Piars;

namespace PiarServer.Application.Piars.UpdatePiar;

internal class UpdatePiarPt2CommandHandler : ICommandHandler<UpdatePiarPt2Command, Guid>
{
    private readonly IPiarRepository _piarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePiarPt2CommandHandler(IPiarRepository piarRepository, IUnitOfWork unitOfWork)
    {
        _piarRepository = piarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdatePiarPt2Command request, CancellationToken cancellationToken)
    {
        var piar = await _piarRepository.GetByIdAsync(request.id);

        if (piar is null)
        {
            return Result.Failure<Guid>(PiarErrors.NotFound);
        }

        var diligenciamientoDos = new DiligenciamientoDos(
            request.fec_dig_a2,
            request.inst_edu_a2,
            request.sed_a2,
            request.jor_a2,
            request.docs_ela,
            request.grd_est
        );

        var caractEstudiante = new CaracteristicasEstudiante(
            request.desc_1_est,
            request.desc_2_est
        );

        piar.UpdatePt2(
            diligenciamientoDos,
            caractEstudiante
        );

        await _piarRepository.UpdatePt2( piar, cancellationToken );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return piar.Id!;
    }
}
