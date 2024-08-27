using FluentValidation;

namespace PiarServer.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandValidator
    : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre no puede ser nulo");
        RuleFor(c => c.Apellido).NotEmpty().WithMessage("Los apellidos no pueden ser nulos");
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(5);
    }
}