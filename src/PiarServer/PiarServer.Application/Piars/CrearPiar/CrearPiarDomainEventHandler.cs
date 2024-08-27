using MediatR;
using PiarServer.Application.Abstractions.Email;
using PiarServer.Domain.Piars;
using PiarServer.Domain.Piars.Events;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Piars.CrearPiar;

internal sealed class CrearPiarDomainEventHandler
: INotificationHandler<PiarCreadoDomainEvent>
{
    private readonly IPiarRepository _piarRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public CrearPiarDomainEventHandler(
        IPiarRepository piarRepository, 
        IUserRepository userRepository,
        IEmailService emailService
    )
    {
        _piarRepository = piarRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(
        PiarCreadoDomainEvent notification, 
        CancellationToken cancellationToken
    )
    {
        var piar = await _piarRepository
        .GetByIdAsync(notification.PiarId, cancellationToken);
        
        if (piar is null)
        {
            return;
        }

        var user = await _userRepository
        .GetByIdAsync(piar.IdUss, cancellationToken);

        if (user is null)
        {
            return;
        }

        _emailService.Send(
            user.Email!.Value,
            "Piar Creado",
            "Has creado un nuevo Piar"
        );

    }
}