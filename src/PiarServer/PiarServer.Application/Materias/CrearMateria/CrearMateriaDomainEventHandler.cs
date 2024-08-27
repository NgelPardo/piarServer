using MediatR;
using PiarServer.Application.Abstractions.Email;
using PiarServer.Domain.Materias;
using PiarServer.Domain.Materias.Events;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Materias.CrearMateria;

internal sealed class CrearMateriaDomainEventHandler
: INotificationHandler<MateriaCreadaDomainEvent>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public CrearMateriaDomainEventHandler(
        IMateriaRepository materiaRepository, 
        IUserRepository userRepository, 
        IEmailService emailService
    )
    {
        _materiaRepository = materiaRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(
        MateriaCreadaDomainEvent notification, 
        CancellationToken cancellationToken
    )
    {
        var materia = await _materiaRepository
        .GetByIdAsync(notification.IdMat, cancellationToken);

        if (materia is null)
        {
            return;
        }

        var user = await _userRepository
        .GetByIdAsync(materia.IdUss, cancellationToken);

        if (user is null)
        {
            return;
        }

        // _emailService.Send(
        //     user.Email!.Value,
        //     "Materia Creada",
        //     "Has creado una nueva materia"
        // );
    }
}