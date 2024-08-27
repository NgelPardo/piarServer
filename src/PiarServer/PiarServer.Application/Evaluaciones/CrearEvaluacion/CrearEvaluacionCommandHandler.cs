using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Evaluaciones;
using PiarServer.Domain.Materias;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Evaluaciones.CrearEvaluacion;

internal sealed class CrearEvaluacionCommandHandler :
    ICommandHandler<CrearEvaluacionCommand, Guid>
{
    private readonly IEvaluacionRepository _evaluacionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CrearEvaluacionCommandHandler(IEvaluacionRepository evaluacionRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _evaluacionRepository = evaluacionRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<Guid>> Handle(CrearEvaluacionCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.IdUss);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var informacion = new Domain.Evaluaciones.Informacion(request.DescEva);

        try
        {
            var evaluacion = Evaluacion.Crear(
                request.IdMat,
                informacion,
                request.FecDil
            );

            _evaluacionRepository.Add(evaluacion);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return evaluacion.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaErrors.Overlap);
        }
    }
}
