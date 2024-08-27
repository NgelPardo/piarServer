using Dapper;
using MediatR;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.AjustesPiar.GetAjustesPiar;
using PiarServer.Application.BarrerasPiar.GetBarrerasPiar;
using PiarServer.Application.EvaluacionesPiar.GetEvaluacionesPiar;
using PiarServer.Application.MateriasPiar.GetMateriasPiar;
using PiarServer.Application.ObjetivosPiar.GetObjetivosPiar;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.MateriasPiar.GetMateriasPiar;

internal sealed class GetMateriasPiarQueryHandler
    : IQueryHandler<GetMateriasPiarQuery, IReadOnlyList<MateriaPiarResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly ISender _sender;

    public GetMateriasPiarQueryHandler(ISqlConnectionFactory sqlConnectionFactory, ISender sender)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _sender = sender;
    }

    public async Task<Result<IReadOnlyList<MateriaPiarResponse>>> Handle(GetMateriasPiarQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                MATP.id,
                MATP.id_piar,
                MATP.id_mat,
                MATP.materia AS sem_mat,
                MAT.nom_mat_nom_mat AS nom_mat,
                OP.id,
                OP.id_mat,
                OP.id_obj,
                OP.id_piar,
                OB.desc_obj,
                OP.sem_obj,
                BP.id,
                BP.id_mat,
                BP.id_barr,
                BP.id_piar,
                BR.desc_barr,
                BP.sem_barr,
                AP.id,
                AP.id_mat,
                AP.id_ajt,
                AP.id_piar,
                AJ.desc_ajt,
                AP.sem_ajt,
                EP.id,
                EP.id_mat,
                EP.id_eva,
                EP.id_piar,
                EV.desc_eva,
                EP.sem_eva 
            FROM materias_piar MATP
                INNER JOIN materias MAT ON MAT.id = MATP.id_mat
                LEFT JOIN objetivos_piar OP ON OP.id_mat = MATP.id
                LEFT JOIN objetivos OB ON OB.id = OP.id_obj 
                LEFT JOIN barreras_piar BP ON BP.id_mat = MATP.id
                LEFT JOIN barreras BR ON BR.id = BP.id_barr
                LEFT JOIN ajustes_piar AP ON AP.id_mat = MATP.id 
                LEFT JOIN ajustes AJ ON AJ.id = AP.id_ajt
                LEFT JOIN evaluaciones_piar EP ON EP.id_mat = MATP.id
                LEFT JOIN evaluaciones EV ON EV.id = EP.id_eva
            WHERE MATP.id_piar = @Id
        """;

        var materiaDictionary = new Dictionary<Guid, MateriaPiarResponse>();

        var materiasPiar = await connection.QueryAsync<MateriaPiarResponse, ObjetivoPiarResponse, BarreraPiarResponse, AjustePiarResponse, EvaluacionPiarResponse, MateriaPiarResponse>(
            sql,
            (materia, objetivo, barrera, ajuste, evaluacion) =>
            {
                if (!materiaDictionary.TryGetValue(materia.id, out var materiaEntry))
                {
                    materiaEntry = materia;
                    materiaEntry.objetivos = new List<ObjetivoPiarResponse>();
                    materiaEntry.barreras = new List<BarreraPiarResponse>();
                    materiaEntry.ajustes = new List<AjustePiarResponse>();
                    materiaEntry.evaluaciones = new List<EvaluacionPiarResponse>();
                    materiaDictionary.Add(materia.id, materiaEntry);
                }

                if (objetivo != null && objetivo.id != Guid.Empty && !materiaEntry.objetivos!.Any(o => o.id == objetivo.id)) 
                    materiaEntry.objetivos!.Add(objetivo);
                if (barrera != null && barrera.id != Guid.Empty && !materiaEntry.barreras!.Any(b => b.id == barrera.id)) 
                    materiaEntry.barreras!.Add(barrera);
                if (ajuste != null && ajuste.id != Guid.Empty && !materiaEntry.ajustes!.Any(a => a.id == ajuste.id)) 
                    materiaEntry.ajustes!.Add(ajuste);
                if (evaluacion != null && evaluacion.id != Guid.Empty && !materiaEntry.evaluaciones!.Any(e => e.id == evaluacion.id)) 
                    materiaEntry.evaluaciones!.Add(evaluacion);

                return materiaEntry;
            },
            new { request.Id },
            splitOn: "id,id,id,id"
        );

        IReadOnlyList<MateriaPiarResponse> readonlyList = materiaDictionary.Values.ToList();
        return Result<IReadOnlyList<MateriaPiarResponse>>.Success(readonlyList);

    }
}
