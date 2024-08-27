using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.ObjetivosPiar.GetObjetivosPiar;

internal sealed class GetObjetivosPiarQueryHandler : IQueryHandler<GetObjetivosPiarQuery, IReadOnlyList<ObjetivoPiarResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetObjetivosPiarQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<ObjetivoPiarResponse>>> Handle(GetObjetivosPiarQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id,
                id_mat,
                id_obj,
                id_piar,
                sem_obj
            FROM objetivos_piar
            WHERE id_mat = @Id
        """;

        var objetivosPiar = await connection.QueryAsync<ObjetivoPiarResponse>(
            sql,
            new 
            {
                request.Id
            }
        );

        return objetivosPiar.ToList();
    }
}
