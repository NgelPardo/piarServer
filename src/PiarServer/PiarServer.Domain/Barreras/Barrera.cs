using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Barreras.Events;

namespace PiarServer.Domain.Barreras;

public sealed class Barrera : Entity
{
    private Barrera(){}
    private Barrera(
        Guid idBarr,
        Guid idMat,
        Informacion? descBarr,
        DateTime? fecDil
        ) : base(idBarr)
    {
        IdMat = idMat;
        DescBarr = descBarr;
        FecDil = fecDil;
    }

    public Guid? IdMat {get; private set;}
    public Informacion? DescBarr {get; private set;}
    public DateTime? FecDil {get; private set;}

    public static Barrera Crear(
        Guid idMat,
        Informacion? descBarr,
        DateTime? fecDil
    )
    {
        var barrera = new Barrera(
            Guid.NewGuid(),
            idMat,
            descBarr,
            fecDil
        );

        barrera.RaiseDomainEvent(new BarreraCreadaDomainEvent(barrera.Id!));

        return barrera;
    }

    public void Update(
        Informacion descBarr
    )
    {
        DescBarr = descBarr;
    }
}