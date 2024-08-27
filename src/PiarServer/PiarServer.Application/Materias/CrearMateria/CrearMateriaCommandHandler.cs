using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Materias;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Materias.CrearMateria;

internal sealed class CrearMateriaCommandHandler :
    ICommandHandler<CrearMateriaCommand, Guid>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrearMateriaCommandHandler(
        IMateriaRepository materiaRepository, 
        IUserRepository userRepository, 
        IUnitOfWork unitOfWork
    )
    {
        _materiaRepository = materiaRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CrearMateriaCommand request, 
        CancellationToken cancellationToken
    )
    {
        var user = await _userRepository.GetByIdAsync(request.IdUss, cancellationToken);
        var informacion = new Informacion(request.NomMat, request.GrdMat);

        if(user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        //TODO: Manejar los diferentes posibles errores

        try
        {
            var materia = Materia.Crear(
                request.IdUss, //request.IdUss o user ??
                request.IdProf,
                informacion,
                request.FecDil
            );

            _materiaRepository.Add(materia);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return materia.Id;

        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaErrors.Overlap);
        }

    }
}