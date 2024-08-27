using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.MateriasPiar;
using PiarServer.Domain.Piars;

namespace PiarServer.Application.MateriasPiar.CrearMateriaPiar;

internal sealed class CrearMateriaPiarCommandHandler :
    ICommandHandler<CrearMateriaPiarCommand, Guid>
{
    private readonly IMateriaPiarRepository _materiaPiarRepository;
    private readonly IPiarRepository _piarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrearMateriaPiarCommandHandler(IMateriaPiarRepository materiaPiarRepository, IPiarRepository piarRepository, IUnitOfWork unitOfWork)
    {
        _materiaPiarRepository = materiaPiarRepository;
        _piarRepository = piarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CrearMateriaPiarCommand request, CancellationToken cancellationToken)
    {
        var piar = await _piarRepository.GetByIdAsync(request.IdPiar);

        if (piar is null)
        {
            return Result.Failure<Guid>(PiarErrors.NotFound);
        }

        try
        {
            var materiaPiar = MateriaPiar.Crear(
                request.IdPiar,
                request.IdMat,
                new Materia(request.SemMat)
            );

            _materiaPiarRepository.Add(materiaPiar);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return materiaPiar.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaPiarErrors.Overlap);
        }
    }
}
