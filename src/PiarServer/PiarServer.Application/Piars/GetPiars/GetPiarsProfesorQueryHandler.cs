using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Piars.GetPiars;

internal sealed class GetPiarsProfesorQueryHandler
    : IQueryHandler<GetPiarsProfesorQuery, IReadOnlyList<PiarsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetPiarsProfesorQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<PiarsResponse>>> Handle(GetPiarsProfesorQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """
            SELECT 
                id,
                estudiante_nom_est AS NomEst,
                estudiante_doc_est AS DocEst,
                diligenciamiento_uno_fec_dil AS FecDil,
                est_piar AS EstPiar,
                educativo_ult_grado AS UltGrado
            FROM piars
            WHERE id_uss = @Id
        """;

        var piarList = await connection
            .QueryAsync<PiarsResponse>(
                sql,
                new
                {
                    request.Id
                }
            );

        return piarList.ToList();
    }
}
