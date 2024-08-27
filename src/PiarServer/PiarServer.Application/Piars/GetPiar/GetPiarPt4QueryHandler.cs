using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Piars.GetPiar;

internal sealed class GetPiarPt4QueryHandler
    : IQueryHandler<GetPiarPt4Query, PiarPt4Response>
{
    private readonly ISqlConnectionFactory _sqConnectionFactory;

    public GetPiarPt4QueryHandler(ISqlConnectionFactory sqConnectionFactory)
    {
        _sqConnectionFactory = sqConnectionFactory;
    }

    public async Task<Result<PiarPt4Response>> Handle(GetPiarPt4Query request, CancellationToken cancellationToken)
    {
        using var connection = _sqConnectionFactory.CreateConnection();

        var sql = """
            SELECT
                id,
                COALESCE(diligenciamiento_tres_fec_dil_a3, NOW()) AS fec_dil_a3,
                COALESCE(diligenciamiento_tres_acts_apo, '[{}]') AS acts_apo,
                COALESCE(diligenciamiento_tres_doc_dir, '[{}]') AS doc_dir,
                COALESCE(diligenciamiento_tres_inst_edu_a3, '') AS inst_edu_a3,
                COALESCE(diligenciamiento_tres_nom_fam, '[{}]') AS nom_fam,
                COALESCE(diligenciamiento_tres_compromisos, '') AS compromisos
            FROM piars WHERE id = @PiarId
        """;

        var piar = await connection.QueryFirstOrDefaultAsync<PiarPt4Response>(
            sql,
            new
            {
                request.PiarId
            }
        );

        return piar!;
    }
}
