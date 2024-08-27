using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.AjustesPiar.GetAjustesPiar;

internal sealed class GetAjustesPiarQueryHandler : IQueryHandler<GetAjustesPiarQuery, IReadOnlyList<AjustePiarResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAjustesPiarQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AjustePiarResponse>>> Handle(GetAjustesPiarQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id,
                id_mat,
                id_ajt,
                id_piar,
                sem_ajt
            FROM ajustes_piar
            WHERE id_mat = @Id
        """;

        var ajustesPiar = await connection.QueryAsync<AjustePiarResponse>(
            sql,
            new
            {
                request.Id
            }
        );

        return ajustesPiar.ToList();
    }
}
