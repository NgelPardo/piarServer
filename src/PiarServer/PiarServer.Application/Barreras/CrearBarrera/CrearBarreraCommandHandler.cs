using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Barreras;
using PiarServer.Domain.Materias;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Barreras.CrearBarrera;

internal sealed class CrearBarreraCommandHandler :
    ICommandHandler<CrearBarreraCommand, Guid>
{
    private readonly IBarreraRepository _barreraRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CrearBarreraCommandHandler(IBarreraRepository barreraRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _barreraRepository = barreraRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<Guid>> Handle(CrearBarreraCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.IdUss);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var informacion = new Domain.Barreras.Informacion(request.DescBarr);

        try
        {
            var barrera = Barrera.Crear(
                request.IdMat,
                informacion,
                request.FecDil
            );

            _barreraRepository.Add(barrera);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return barrera.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaErrors.Overlap);
        }
    }
}
