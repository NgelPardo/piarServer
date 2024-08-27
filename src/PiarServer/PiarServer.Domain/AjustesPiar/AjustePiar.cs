using PiarServer.Domain.Abstractions;
using PiarServer.Domain.AjustesPiar.Events;

namespace PiarServer.Domain.AjustesPiar;

public sealed class AjustePiar : Entity
{
    private AjustePiar(){}
    private AjustePiar(
        Guid idAjtPiar,
        Guid idAjt,
        Guid idMat,
        Guid idPiar,
        Ubicacion semAjt
        ) : base(idAjtPiar)
    {
        IdMat = idMat;
        IdAjt = idAjt;
        IdPiar = idPiar;
        SemAjt = semAjt;
    }
    public Guid? IdMat {get; private set;}
    public Guid? IdAjt {get; private set;}
    public Guid? IdPiar{get; private set;}
    public Ubicacion? SemAjt {get; private set;}

    public static AjustePiar Crear(
        Guid idMat,
        Guid idAjt,
        Guid idPiar,
        Ubicacion semAjt
    )
    {
        var ajustePiar = new AjustePiar(
            Guid.NewGuid(),
            idAjt,
            idMat,
            idPiar,
            semAjt
        );

        ajustePiar.RaiseDomainEvent(new AjustePiarCreadoDomainEvent(ajustePiar.Id!));

        return ajustePiar;
    }
}