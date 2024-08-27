using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Ajustes.GetAjustes;

internal sealed class GetAjustesQueryHandler : IQueryHandler<GetAjustesQuery, IReadOnlyList<AjusteResponse>>
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public GetAjustesQueryHandler(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Result<IReadOnlyList<AjusteResponse>>> Handle(GetAjustesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                id,
                id_mat,
                desc_ajt,
                fec_dil
            FROM ajustes
            WHERE id_mat = @Id
        """;

        var ajustes = await connection.QueryAsync<AjusteResponse>(
            sql,
            new
            {
                request.Id
            }
        );

        return ajustes.ToList();
    }
}
