using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.BarrerasPiar.GetBarrerasPiar;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.BarrerasPiar.GetBarrerasPiar;

internal sealed class GetBarrerasPiarQueryHandler : IQueryHandler<GetBarrerasPiarQuery, IReadOnlyList<BarreraPiarResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetBarrerasPiarQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<BarreraPiarResponse>>> Handle(GetBarrerasPiarQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id,
                id_mat,
                id_barr,
                id_piar,
                sem_barr
            FROM barreras_piar
            WHERE id_mat = @Id
        """;

        var barrerasPiar = await connection.QueryAsync<BarreraPiarResponse>(
            sql,
            new
            {
                request.Id
            }
        );

        return barrerasPiar.ToList();
    }
}
