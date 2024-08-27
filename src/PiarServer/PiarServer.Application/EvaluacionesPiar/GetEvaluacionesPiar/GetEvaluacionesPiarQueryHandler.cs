using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.EvaluacionesPiar.GetEvaluacionesPiar;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.EvaluacionesPiar.GetEvaluacionesPiar;

internal sealed class GetEvaluacionesPiarQueryHandler : IQueryHandler<GetEvaluacionesPiarQuery, IReadOnlyList<EvaluacionPiarResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetEvaluacionesPiarQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<EvaluacionPiarResponse>>> Handle(GetEvaluacionesPiarQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id,
                id_mat,
                id_eva,
                id_piar,
                sem_eva
            FROM evaluaciones_piar
            WHERE id_mat = @Id
        """;

        var evaluacionesPiar = await connection.QueryAsync<EvaluacionPiarResponse>(
            sql,
            new
            {
                request.Id
            }
        );

        return evaluacionesPiar.ToList();
    }
}
