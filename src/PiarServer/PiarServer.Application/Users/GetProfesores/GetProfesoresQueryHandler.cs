using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Users.GetUsers;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Users.GetProfesores;

internal sealed class GetProfesoresQueryHandler
    : IQueryHandler<GetProfesoresQuery, IReadOnlyList<UsersResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetProfesoresQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<UsersResponse>>> Handle(GetProfesoresQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                usr.id,
                usr.nombre_nombres AS nombres,
                usr.apellido_apellidos AS apellidos,
                usr.email,
                usr.fec_dil,
                rl.name as rol,
                rl.id as id_rol
            FROM users usr
                LEFT JOIN user_roles usrl
                    ON usr.id = usrl.id_uss
                LEFT JOIN roles rl
                    ON rl.id = usrl.role_id
            WHERE rl.name != 'Auxiliar'
        """;

        var profesores = await connection
            .QueryAsync<UsersResponse>
            (
                sql
            );

        return profesores.ToList();
    }
}
