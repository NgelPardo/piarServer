using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Users.UpdateUser;

internal class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        var userRole = await _userRepository.GetByIdUserRoleAsync(request.Id);

        if ( user is null )
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        user.Update(
            new Nombre(request.Nombre),
            new Apellido(request.Apellido)
        );

        if ( userRole is not null && (userRole.RoleId != request.Rol) )
        {
            _userRepository.RemoveRole(userRole);
            var newUserRole = new UserRole
            {
                RoleId = request.Rol,
                idUss = user.Id
            };

            await _userRepository.AddUserRoleAsync(newUserRole);
        }

        await _userRepository.Update( user, cancellationToken );

        //await _userRepository.UpdateUserRoleAsync(userRole!, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id!;
    }
}
