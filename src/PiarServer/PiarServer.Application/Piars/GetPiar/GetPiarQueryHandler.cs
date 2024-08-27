using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Piars.GetPiar;

internal sealed class GetPiarQueryHandler 
    : IQueryHandler<GetPiarQuery, PiarResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetPiarQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<PiarResponse>> Handle(
        GetPiarQuery request, 
        CancellationToken cancellationToken
    )
    {
        
        using var connection = _sqlConnectionFactory.CreateConnection();

        //TODO: Definir campos que va a devoler la consulta para optimizarla
        var sql = """
            SELECT 
                *
            FROM piar WHERE idPiar=@PiarId
        """;

        var piar = await connection.QueryFirstOrDefaultAsync<PiarResponse>(
            sql,
            new {
                request.PiarId
            }
        );

        return piar!;
    }
}