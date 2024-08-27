using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Piars.GetPiar;

internal sealed class GetPiarPt2QueryHandler
    : IQueryHandler<GetPiarPt2Query, PiarPt2Response>
{
    private readonly ISqlConnectionFactory _sqConnectionFactory;

    public GetPiarPt2QueryHandler(ISqlConnectionFactory sqConnectionFactory)
    {
        _sqConnectionFactory = sqConnectionFactory;
    }

    public async Task<Result<PiarPt2Response>> Handle(GetPiarPt2Query request, CancellationToken cancellationToken)
    {
        using var connection = _sqConnectionFactory.CreateConnection();

        var sql = """
            SELECT
                id,
                COALESCE(diligenciamiento_dos_fec_dig_a2, NOW()) AS fec_dig_a2,
                COALESCE(diligenciamiento_dos_inst_edu_a2, '') AS inst_edu_a2,
                COALESCE(diligenciamiento_dos_sed_a2, '') AS sed_a2,
                COALESCE(diligenciamiento_dos_jor_a2, '') AS jor_a2,
                COALESCE(diligenciamiento_dos_docs_ela, '[{}]') AS docs_ela,
                COALESCE(diligenciamiento_dos_grd_est, '') AS grd_est,
                COALESCE(caracteristicas_estudiante_desc1est, '') AS desc_1_est,
                COALESCE(caracteristicas_estudiante_desc2est, '') AS desc_2_est
            FROM piars WHERE id = @PiarId
        """;

        var piar = await connection.QueryFirstOrDefaultAsync<PiarPt2Response>(
            sql,
            new
            {
                request.PiarId
            }
        );

        return piar!;
    }
}
