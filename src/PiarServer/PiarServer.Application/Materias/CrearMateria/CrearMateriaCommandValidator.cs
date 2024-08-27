using FluentValidation;
using PiarServer.Application.Materias.CrearMateria;

namespace PiarServer.Application.Piars.Materias;

public class CrearMateriaCommandValidator : AbstractValidator<CrearMateriaCommand>
{
    public CrearMateriaCommandValidator()
    {
        RuleFor(c => c.IdUss).NotEmpty();
        RuleFor(c => c.IdProf).NotEmpty();
    }
}