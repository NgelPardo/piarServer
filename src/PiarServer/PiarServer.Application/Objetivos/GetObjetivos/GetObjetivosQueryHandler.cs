using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Objetivos.GetObjetivos;

internal sealed class GetObjetivosQueryHandler : IQueryHandler<GetObjetivosQuery, IReadOnlyList<ObjetivoResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetObjetivosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<ObjetivoResponse>>> Handle(GetObjetivosQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                id,
                id_mat,
                desc_obj,
                fec_dil
            FROM objetivos
            WHERE id_mat = @Id
        """;

        var objetivos = await connection.QueryAsync<ObjetivoResponse>(
            sql,
            new
            {
                request.Id
            }
        );

        return objetivos.ToList();
    }
}
