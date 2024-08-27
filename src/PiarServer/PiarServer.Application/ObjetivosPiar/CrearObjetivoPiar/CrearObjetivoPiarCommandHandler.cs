using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.MateriasPiar;
using PiarServer.Domain.ObjetivosPiar;

namespace PiarServer.Application.ObjetivosPiar.CrearObjetivoPiar;

internal sealed class CrearObjetivoPiarCommandHandler :
    ICommandHandler<CrearObjetivoPiarCommand, Guid>
{
    private readonly IObjetivoPiarRepository _objetivoPiarRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMateriaPiarRepository _materiaPiarRepository;

    public CrearObjetivoPiarCommandHandler(IObjetivoPiarRepository objetivoPiarRepository, IUnitOfWork unitOfWork, IMateriaPiarRepository materiaPiarRepository)
    {
        _objetivoPiarRepository = objetivoPiarRepository;
        _unitOfWork = unitOfWork;
        _materiaPiarRepository = materiaPiarRepository;
    }

    public async Task<Result<Guid>> Handle(CrearObjetivoPiarCommand request, CancellationToken cancellationToken)
    {
        var materiaPiar = await _materiaPiarRepository.GetByIdAsync(request.IdMat);

        if(materiaPiar is null)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.NotFound);
        }

        try
        {
            var objetivoPiar = ObjetivoPiar.Crear(
                request.IdMat,
                request.IdObj,
                request.IdPiar,
                new Ubicacion(request.SemObj)
            );

            _objetivoPiarRepository.Add(objetivoPiar);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return objetivoPiar.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.Overlap);
        }
    }
}
