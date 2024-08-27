using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Objetivos.Events;

namespace PiarServer.Domain.Objetivos;

public sealed class Objetivo : Entity
{
    private Objetivo() { }
    private Objetivo(
        Guid idObj,
        Guid idMat,
        Informacion? descObj,
        DateTime? fecDil
        ) : base(idObj)
    {
        IdMat = idMat;
        DescObj = descObj;
        FecDil = fecDil;
    }

    public Guid? IdMat { get; private set; }
    public Informacion? DescObj { get; private set; }
    public DateTime? FecDil { get; private set; }
    public static Objetivo Crear(
        Guid idMat,
        Informacion? descObj,
        DateTime? fecDil
    )
    {
        var objetivo = new Objetivo(
            Guid.NewGuid(),
            idMat,
            descObj,
            fecDil
        );

        objetivo.RaiseDomainEvent(new ObjetivoCreadoDomainEvent(objetivo.Id!));

        return objetivo;
    }

    public void Update(
        Informacion descObj
    )
    {
        DescObj = descObj;
    }
}