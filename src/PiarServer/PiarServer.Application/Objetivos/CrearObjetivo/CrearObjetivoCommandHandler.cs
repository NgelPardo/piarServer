using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Materias;
using PiarServer.Domain.Objetivos;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Objetivos.CrearObjetivo;

internal sealed class CrearObjetivoCommandHandler :
    ICommandHandler<CrearObjetivoCommand, Guid>
{
    private readonly IObjetivoRepository _objetivoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMateriaRepository _materiaRepository;

    public CrearObjetivoCommandHandler(IObjetivoRepository objetivoRepository, IUnitOfWork unitOfWork, IMateriaRepository materiaRepository)
    {
        _objetivoRepository = objetivoRepository;
        _unitOfWork = unitOfWork;
        _materiaRepository = materiaRepository;
    }

    public async Task<Result<Guid>> Handle(CrearObjetivoCommand request, CancellationToken cancellationToken)
    {
        var materia = await _materiaRepository.GetByIdAsync(request.IdMat);

        if(materia is null)
        {
            return Result.Failure<Guid>(MateriaErrors.NotFound);
        }

        var informacion = new Domain.Objetivos.Informacion(request.DescObj);

        try
        {
            var objetivo = Objetivo.Crear(
                request.IdMat,
                informacion,
                request.FecDil
            );

            _objetivoRepository.Add(objetivo);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return objetivo.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaErrors.Overlap);
        }
    }
}
