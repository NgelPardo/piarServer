using PiarServer.Domain.Abstractions;
using PiarServer.Domain.ObjetivosPiar.Events;

namespace PiarServer.Domain.ObjetivosPiar;

public sealed class ObjetivoPiar : Entity
{
    private ObjetivoPiar(){}
    private ObjetivoPiar(
        Guid idObjPiar,
        Guid idObj,
        Guid idMat,
        Guid idPiar,
        Ubicacion? semObj
        ) : base(idObjPiar)
    {
        IdMat = idMat;
        IdObj = idObj;
        IdPiar = idPiar;
        SemObj = semObj;
    }
    public Guid? IdMat {get; private set;}
    public Guid? IdObj {get; private set;}
    public Guid? IdPiar {get; private set;}
    public Ubicacion? SemObj {get; private set;}
    public static ObjetivoPiar Crear(
        Guid idMat,
        Guid idObj,
        Guid idPiar,
        Ubicacion? semObj
    )
    {
        var objetivoPiar = new ObjetivoPiar(
            Guid.NewGuid(),
            idObj,
            idMat,
            idPiar,
            semObj
        );

        objetivoPiar.RaiseDomainEvent(new ObjetivoPiarCreadoDomainEvent(objetivoPiar.Id!));

        return objetivoPiar;
    }
}