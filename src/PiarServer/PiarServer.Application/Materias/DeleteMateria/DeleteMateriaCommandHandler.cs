using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Materias;

namespace PiarServer.Application.Materias.DeleteMateria;

internal sealed class DeleteMateriaCommandHandler : ICommandHandler<DeleteMateriaCommand, Guid>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMateriaCommandHandler(IMateriaRepository materiaRepository, IUnitOfWork unitOfWork)
    {
        _materiaRepository = materiaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteMateriaCommand request, CancellationToken cancellationToken)
    {
        var materia = await _materiaRepository.GetByIdAsync( request.Id );

        if(materia is null)
        {
            return Result.Failure<Guid>(MateriaErrors.NotFound);
        }

        _materiaRepository.Remove(materia);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(materia.Id);
    }
}
