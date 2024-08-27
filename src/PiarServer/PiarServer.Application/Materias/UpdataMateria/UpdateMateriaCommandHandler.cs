using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Materias;

namespace PiarServer.Application.Materias.UpdateMateria;

internal class UpdateMateriaCommandHandler : ICommandHandler<UpdateMateriaCommand, Guid>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateMateriaCommandHandler(IMateriaRepository materiaRepository, IUnitOfWork unitOfWork)
    {
        _materiaRepository = materiaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateMateriaCommand request, CancellationToken cancellationToken)
    {
        var materia = await _materiaRepository.GetByIdAsync(request.Id);

        if ( materia is null )
        {
            return Result.Failure<Guid>(MateriaErrors.NotFound);
        }

        materia.Update(
            request.IdProf,
            new Informacion(request.NomMat!, request.GrdMat!)
        );

        await _materiaRepository.Update(materia, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return materia.Id!;
    }
}
