using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Ajustes;
using PiarServer.Domain.Materias;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Ajustes.CrearAjuste;

internal sealed class CrearAjusteCommandHandler :
    ICommandHandler<CrearAjusteCommand, Guid>
{
    private readonly IAjusteRepository _ajusteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CrearAjusteCommandHandler(IAjusteRepository ajusteRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _ajusteRepository = ajusteRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<Guid>> Handle(CrearAjusteCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.IdUss);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var informacion = new Domain.Ajustes.Informacion(request.DescAjt);

        try
        {
            var ajuste = Ajuste.Crear(
                request.IdMat,
                informacion,
                request.FecDil
            );

            _ajusteRepository.Add(ajuste);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ajuste.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(MateriaErrors.Overlap);
        }
    }
}
