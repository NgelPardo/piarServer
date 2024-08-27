using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.AjustesPiar;
using PiarServer.Domain.MateriasPiar;

namespace PiarServer.Application.AjustesPiar.CrearAjustePiar;

internal sealed class CrearAjustePiarCommandHandler :
    ICommandHandler<CrearAjustePiarCommand, Guid>
{
    private readonly IAjustePiarRepository _ajustePiarRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMateriaPiarRepository _materiaPiarRepository;

    public CrearAjustePiarCommandHandler(IAjustePiarRepository ajustePiarRepository, IUnitOfWork unitOfWork, IMateriaPiarRepository materiaPiarRepository)
    {
        _ajustePiarRepository = ajustePiarRepository;
        _unitOfWork = unitOfWork;
        _materiaPiarRepository = materiaPiarRepository;
    }

    public async Task<Result<Guid>> Handle(CrearAjustePiarCommand request, CancellationToken cancellationToken)
    {
        var materiaPiar = await _materiaPiarRepository.GetByIdAsync(request.IdMat);

        if (materiaPiar is null)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.NotFound);
        }

        try
        {
            var ajustePiar = AjustePiar.Crear(
                request.IdMat,
                request.IdAjt,
                request.IdPiar,
                new Ubicacion(request.SemAjt)
            );

            _ajustePiarRepository.Add(ajustePiar);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ajustePiar.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.Overlap);
        }
    }
}
