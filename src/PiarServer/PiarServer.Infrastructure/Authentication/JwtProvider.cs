using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PiarServer.Application.Abstractions.Authentication;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Domain.Users;

namespace PiarServer.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public JwtProvider(IOptions<JwtOptions> options, ISqlConnectionFactory sqlConnectionFactory)
    {
        _options = options.Value;
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<string> Generate(User user)
    {
        const string sqlPermissions = """
            SELECT
                p.nombre
            FROM users usr
                LEFT JOIN user_roles usrl
                    ON usr.id = usrl.id_uss
                LEFT JOIN roles rl
                    ON rl.id = usrl.role_id
                LEFT JOIN roles_permissions rp
                    ON rl.id = rp.role_id
                LEFT JOIN permissions p 
                    ON p.id = rp.permission_id
                WHERE usr.id = @UserId
        """;

        const string sqlRoles = """
            SELECT 
                rl.name
            FROM users usr
                LEFT JOIN user_roles usrl
                    ON usr.id = usrl.id_uss
                LEFT JOIN roles rl
                    ON rl.id = usrl.role_id
                WHERE usr.id = @UserId
        """;

        using var connection = _sqlConnectionFactory.CreateConnection();
        var permissions = await connection.QueryAsync<string>(sqlPermissions, new { UserId = user.Id! });
        var roles = await connection.QueryAsync<string>(sqlRoles, new { UserId = user.Id! });

        var permissionCollection = permissions.ToHashSet();
        var rolesCollection = roles.ToHashSet();

        var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.Sub, user.Id!.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!.Value),
            new Claim(JwtRegisteredClaimNames.Name, user.Nombre!.Nombres),
        };

        foreach(var permission in permissionCollection)
        {
            claims.Add(new (CustomClaims.Permissions, permission));
        }

        foreach(var role in rolesCollection)
        {
            claims.Add(new (CustomClaims.Roles, role));
        }

        var signinCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey!)),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddDays(365),
            signinCredentials
        );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken( token );

        return tokenValue;

    }
}