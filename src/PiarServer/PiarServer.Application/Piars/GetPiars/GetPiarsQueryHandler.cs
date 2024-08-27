using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Piars.GetPiars;

internal sealed class GetPiarsQueryHandler 
    : IQueryHandler<GetPiarsQuery, IReadOnlyList<PiarsResponse>>
{
    private readonly ISqlConnectionFactory _sqConnectionFactory;

    public GetPiarsQueryHandler(ISqlConnectionFactory sqConnectionFactory)
    {
        _sqConnectionFactory = sqConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<PiarsResponse>>> Handle(GetPiarsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqConnectionFactory.CreateConnection();

        var sql = """
            SELECT 
                id,
                estudiante_nom_est AS NomEst,
                estudiante_doc_est AS DocEst,
                diligenciamiento_uno_fec_dil AS FecDil,
                est_piar AS EstPiar,
                educativo_ult_grado AS UltGrado
            FROM piars
        """;

        var piarList = await connection
            .QueryAsync<PiarsResponse>( 
                sql 
            );

        return piarList.ToList();
    }
}
