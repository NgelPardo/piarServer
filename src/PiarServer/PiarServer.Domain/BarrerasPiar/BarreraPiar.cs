using PiarServer.Domain.Abstractions;
using PiarServer.Domain.BarrerasPiar.Events;

namespace PiarServer.Domain.BarrerasPiar;

public sealed class BarreraPiar : Entity
{
    private BarreraPiar(){}
    private BarreraPiar(
        Guid idBarrPiar,
        Guid idBarr,
        Guid idMat,
        Guid idPiar,
        Ubicacion? semBarr
        ) : base(idBarrPiar)
    {
        IdMat = idMat;
        IdBarr = idBarr;
        IdPiar = idPiar;
        SemBarr = semBarr;
    }
    public Guid? IdMat {get; private set;}
    public Guid? IdBarr {get; private set;}
    public Guid? IdPiar {get; private set;}
    public Ubicacion? SemBarr {get; private set;}
    public static BarreraPiar Crear(
        Guid idMat,
        Guid idBarr,
        Guid idPiar,
        Ubicacion? semBarr
    )
    {
        var barreraPiar = new BarreraPiar(
            Guid.NewGuid(),
            idBarr,
            idMat,
            idPiar,
            semBarr
        );

        barreraPiar.RaiseDomainEvent(new BarreraPiarCreadaDomainEvent(barreraPiar.Id!));

        return barreraPiar;
    }
}