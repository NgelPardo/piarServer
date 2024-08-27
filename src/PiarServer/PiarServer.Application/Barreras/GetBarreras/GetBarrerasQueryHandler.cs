using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Barreras.GetBarreras;

internal sealed class GetBarrerasQueryHandler : IQueryHandler<GetBarrerasQuery, IReadOnlyList<BarreraResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetBarrerasQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<BarreraResponse>>> Handle(GetBarrerasQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                id,
                id_mat,
                desc_barr,
                fec_dil
            FROM barreras
            WHERE id_mat = @Id
        """;

        var barreras = await connection.QueryAsync<BarreraResponse>(
            sql,
            new
            {
                request.Id
            }
        );

        return barreras.ToList();
    }
}
