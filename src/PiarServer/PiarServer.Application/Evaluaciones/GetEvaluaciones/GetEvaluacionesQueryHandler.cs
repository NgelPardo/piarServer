using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Evaluaciones.GetEvaluaciones;

internal sealed class GetEvaluacionesQueryHandler : IQueryHandler<GetEvaluacionesQuery, IReadOnlyList<EvaluacionResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetEvaluacionesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<EvaluacionResponse>>> Handle(GetEvaluacionesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                id,
                id_mat,
                desc_eva,
                fec_dil
            FROM evaluaciones
            WHERE id_mat = @Id
        """;

        var evaluaciones = await connection.QueryAsync<EvaluacionResponse>(
            sql,
            new
            {
                request.Id
            }
        );

        return evaluaciones.ToList();
    }
}
