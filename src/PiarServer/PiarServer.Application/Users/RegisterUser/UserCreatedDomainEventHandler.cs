using MediatR;
using PiarServer.Application.Abstractions.Email;
using PiarServer.Domain.Users;
using PiarServer.Domain.Users.Events;

namespace PiarServer.Application.Users.RegisterUser;

internal sealed class UserCreatedDomainEventHandler 
: INotificationHandler<UserCreatedDomainEvent>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public UserCreatedDomainEventHandler(
        IUserRepository userRepository, 
        IEmailService emailService
        )
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(
        UserCreatedDomainEvent notification, 
        CancellationToken cancellationToken
        )
    {
        
        var user = await _userRepository.GetByIdAsync(
            notification.UserId,
            cancellationToken
        );

        if(user is null)
        {
            return;
        }

        string htmlBody = $@"
            <!DOCTYPE html>
            <html lang='es'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f4f4f4;
                        margin: 0;
                        padding: 20px;
                    }}
                    .container {{
                        background-color: #ffffff;
                        padding: 20px;
                        border-radius: 8px;
                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    }}
                    .header {{
                        font-size: 24px;
                        font-weight: bold;
                        color: #333333;
                        margin-bottom: 20px;
                    }}
                    .content {{
                        font-size: 16px;
                        color: #666666;
                        line-height: 1.5;
                    }}
                    .content p {{
                        margin-bottom: 10px;
                    }}
                    .footer {{
                        margin-top: 20px;
                        font-size: 14px;
                        color: #999999;
                    }}
                </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            Se ha creado su cuenta en nuestra aplicación
                        </div>
                        <div class='content'>
                            <p>Tienes una nueva cuenta dentro de PiarApp.</p>
                            <p>Tu contraseña es: <strong>{notification.passwordNoHash}</strong> recuerda actualizarla</p>
                        </div>
                    </div>
                </body>
            </html>";

        _emailService.Send(
            user.Email!.Value,
            "Se ha creado su cuenta en nuestra aplicación.",
            htmlBody
        );
    }
}