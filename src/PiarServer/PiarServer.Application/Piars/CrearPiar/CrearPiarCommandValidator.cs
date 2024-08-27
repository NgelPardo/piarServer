using FluentValidation;

namespace PiarServer.Application.Piars.CrearPiar;

public class CrearPiarCommandValidator : AbstractValidator<CrearPiarCommand>
{
    public CrearPiarCommandValidator()
    {
        RuleFor(c => c.IdUss).NotEmpty();
        RuleFor(c => c.IdProf).NotEmpty();
    }
}