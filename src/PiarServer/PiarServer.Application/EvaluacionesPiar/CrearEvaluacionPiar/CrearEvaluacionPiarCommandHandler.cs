using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.EvaluacionesPiar;
using PiarServer.Domain.MateriasPiar;

namespace PiarServer.Application.EvaluacionesPiar.CrearEvaluacionPiar;

internal sealed class CrearEvaluacionPiarCommandHandler :
    ICommandHandler<CrearEvaluacionPiarCommand, Guid>
{
    private readonly IEvaluacionPiarRepository _evaluacionPiarRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMateriaPiarRepository _materiaPiarRepository;

    public CrearEvaluacionPiarCommandHandler(IEvaluacionPiarRepository evaluacionPiarRepository, IUnitOfWork unitOfWork, IMateriaPiarRepository materiaPiarRepository)
    {
        _evaluacionPiarRepository = evaluacionPiarRepository;
        _unitOfWork = unitOfWork;
        _materiaPiarRepository = materiaPiarRepository;
    }

    public async Task<Result<Guid>> Handle(CrearEvaluacionPiarCommand request, CancellationToken cancellationToken)
    {
        var materiaPiar = await _materiaPiarRepository.GetByIdAsync(request.IdMat);

        if (materiaPiar is null)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.NotFound);
        }

        try
        {
            var evaluacionPiar = EvaluacionPiar.Crear(
                request.IdMat,
                request.IdEva,
                request.IdPiar,
                new Ubicacion(request.SemEva)
            );

            _evaluacionPiarRepository.Add(evaluacionPiar);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return evaluacionPiar.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.Overlap);
        }
    }
}
