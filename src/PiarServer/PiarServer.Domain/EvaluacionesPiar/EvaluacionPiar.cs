using PiarServer.Domain.Abstractions;
using PiarServer.Domain.EvaluacionesPiar.Events;

namespace PiarServer.Domain.EvaluacionesPiar;

public sealed class EvaluacionPiar : Entity
{
    private EvaluacionPiar(){}
    private EvaluacionPiar(
        Guid idEvaPiar,
        Guid idEva,
        Guid idMat,
        Guid idPiar,
        Ubicacion? semEva
        ) : base(idEva)
    {
        IdEva = idEva;
        IdMat = idMat;
        IdPiar = idPiar;
        SemEva = semEva;
    }

    public Guid IdEva { get; set;}
    public Guid? IdMat {get; private set;}
    public Guid? IdPiar {get; private set;}
    public Ubicacion? SemEva {get; private set;}
    public static EvaluacionPiar Crear(
        Guid idMat,
        Guid idEva,
        Guid idPiar,
        Ubicacion? semEva
    ) 
    {
        var evaluacionPiar = new EvaluacionPiar(
            Guid.NewGuid(),
            idEva,
            idMat,
            idPiar,
            semEva
        );

        evaluacionPiar.RaiseDomainEvent(new EvaluacionPiarCreadaDomainEvent(evaluacionPiar.Id!));
 
        return evaluacionPiar;
    }
}