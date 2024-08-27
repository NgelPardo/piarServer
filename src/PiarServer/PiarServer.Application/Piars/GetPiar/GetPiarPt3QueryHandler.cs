using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Piars.GetPiar;

internal sealed class GetPiarPt3QueryHandler
    : IQueryHandler<GetPiarPt3Query, PiarPt3Response>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetPiarPt3QueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<PiarPt3Response>> Handle(GetPiarPt3Query request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """
            SELECT
                id,
                COALESCE(recomendaciones_acc_fam, '') AS acc_fam,
                COALESCE(recomendaciones_estr_fam, '') AS estr_fam,
                COALESCE(recomendaciones_acc_doc, '') AS acc_doc,
                COALESCE(recomendaciones_estr_doc, '') AS estr_doc,
                COALESCE(recomendaciones_acc_dir, '') AS acc_dir,
                COALESCE(recomendaciones_estr_dir, '') AS estr_dir,
                COALESCE(recomendaciones_acc_adm, '') AS acc_adm,
                COALESCE(recomendaciones_estr_adm, '') AS estr_adm,
                COALESCE(recomendaciones_acc_par, '') AS acc_par,
                COALESCE(recomendaciones_estr_par, '') AS estr_par
            FROM piars WHERE id = @PiarId
        """;

        var piar = await connection.QueryFirstOrDefaultAsync<PiarPt3Response>(
            sql,
            new
            {
                request.PiarId
            }
        );

        return piar!;
    }
}
