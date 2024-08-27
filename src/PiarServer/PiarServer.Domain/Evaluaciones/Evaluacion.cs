using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Evaluaciones.Events;

namespace PiarServer.Domain.Evaluaciones;

public sealed class Evaluacion : Entity
{
    private Evaluacion(){}
    private Evaluacion(
        Guid idEva,
        Guid idMat,
        Informacion? descEva,
        DateTime? fecDil
        ) : base(idEva)
    {
        IdMat = idMat;
        DescEva = descEva;
        FecDil = fecDil;
    }

    public Guid? IdMat {get; private set;}
    public Informacion? DescEva {get; private set;}
    public DateTime? FecDil {get; private set;}
    public static Evaluacion Crear(
        Guid idMat,
        Informacion? descEva,
        DateTime? fecDil
    )
    {
        var evaluacion = new Evaluacion(
            Guid.NewGuid(),
            idMat,
            descEva,
            fecDil
        );

        evaluacion.RaiseDomainEvent(new EvaluacionCreadaDomainEvent(evaluacion.Id!));

        return evaluacion;
    }

    public void Update(
        Informacion descEva
    )
    {
        DescEva = descEva;
    }
}