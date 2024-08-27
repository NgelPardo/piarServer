using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Materias.GetMaterias;

internal sealed class GetMateriasQueryHandler
    : IQueryHandler<GetMateriasQuery, IReadOnlyList<MateriaResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetMateriasQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<MateriaResponse>>> Handle(
        GetMateriasQuery request, 
        CancellationToken cancellationToken
    )
    {
        
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS id,
                id_uss AS id_uss,
                id_prof AS id_prof,
                nom_mat_nom_mat AS nom_mat,
                nom_mat_grd_mat AS grd_mat,
                fec_dil AS fec_dil
            FROM materias
            WHERE id_uss = @Id
        """;

        var materias = await connection
            .QueryAsync<MateriaResponse>( 
                sql,
                new {
                    request.Id
                }
        );

        return materias.ToList();
    }
}