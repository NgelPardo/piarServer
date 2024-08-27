using PiarServer.Domain.Abstractions;
using PiarServer.Domain.FirmasPiar.Events;

namespace PiarServer.Domain.FirmasPiar;

public sealed class FirmaPiar : Entity
{
    private FirmaPiar(){}
    private FirmaPiar(
        Guid idFir,
        Guid idPiar,
        Firma? firma
        ) : base(idFir)
    {
        IdPiar = idPiar;
        Firma = firma;
    }

    public Guid? IdPiar {get; private set;}
    public Firma? Firma {get; private set;}
    public static FirmaPiar Crear(
        Guid idPiar,
        Firma? firma
    ){
        var firmaPiar = new FirmaPiar(
            Guid.NewGuid(),
            idPiar,
            firma
        );

        firmaPiar.RaiseDomainEvent(new FirmaCreadaDomainEvent(firmaPiar.Id!));

        return firmaPiar;
    }
}