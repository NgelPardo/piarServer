using PiarServer.Application.Abstractions.Authentication;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Users.LoginUser;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //1. Verificar que exista en DB
        var user = await _userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
        if (user == null)
        {
            return Result.Failure<string>(UserErrors.NotFound);
        }

        //2. Validar que el password es correcto
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash!.Value))
        {
            return Result.Failure<string>(UserErrors.InvalidCredentials);
        }

        //3. Generar el jwt 
        var token = await _jwtProvider.Generate(user);

        //4. return jwt
        return token;
    }
}