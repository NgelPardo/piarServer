using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Users.RegisterUser;

internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
        )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request, 
        CancellationToken cancellationToken
        )
    {
        //1. Validar que el usuario no exista en BD
        var email = new Email(request.Email);
        var userExists = await _userRepository.IsUserExists(email);

        if (userExists)
        {
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        //2. Encriptar el password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        //3. Crear un objeto de tipo User
        var user = User.Create(
            new Nombre(request.Nombre),
            new Apellido(request.Apellido),
            new Email(request.Email),
            new PasswordHash(passwordHash),
            DateTime.UtcNow,
            request.Password
        );

        //4. Insertar el usuario a la BD
        _userRepository.Add(user);

        //5. Insertar el rol del usuario
        var userRole = new UserRole
        {
            RoleId = request.Rol,
            idUss = user.Id
        };

        await _userRepository.AddUserRoleAsync(userRole);

        await _unitOfWork.SaveChangesAsync();

        return user.Id!;
    }
}