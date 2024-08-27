using PiarServer.Domain.Users;

namespace PiarServer.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    Task<string> Generate(User user);
}