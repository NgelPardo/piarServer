using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.BarrerasPiar;
using PiarServer.Domain.MateriasPiar;

namespace PiarServer.Application.BarrerasPiar.CrearBarreraPiar;

internal sealed class CrearBarreraPiarCommandHandler :
    ICommandHandler<CrearBarreraPiarCommand, Guid>
{
    private readonly IBarreraPiarRepository _barreraPiarRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMateriaPiarRepository _materiaPiarRepository;

    public CrearBarreraPiarCommandHandler(IBarreraPiarRepository barreraPiarRepository, IUnitOfWork unitOfWork, IMateriaPiarRepository materiaPiarRepository)
    {
        _barreraPiarRepository = barreraPiarRepository;
        _unitOfWork = unitOfWork;
        _materiaPiarRepository = materiaPiarRepository;
    }

    public async Task<Result<Guid>> Handle(CrearBarreraPiarCommand request, CancellationToken cancellationToken)
    {
        var materiaPiar = await _materiaPiarRepository.GetByIdAsync(request.IdMat);

        if (materiaPiar is null)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.NotFound);
        }

        try
        {
            var barreraPiar = BarreraPiar.Crear(
                request.IdMat,
                request.IdBarr,
                request.IdPiar,
                new Ubicacion(request.SemAjt)
            );

            _barreraPiarRepository.Add(barreraPiar);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return barreraPiar.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.Overlap);
        }
    }
}
