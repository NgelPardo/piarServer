using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Ajustes.Events;

namespace PiarServer.Domain.Ajustes;

public sealed class Ajuste : Entity
{
    private Ajuste()
    {
        
    }
    private Ajuste(
        Guid idAjt,
        Guid idMat,
        Informacion? descAjt,
        DateTime? fecDil
        ) : base(idAjt)
    {
        IdMat = idMat;
        DescAjt = descAjt;
        FecDil = fecDil;
    }
    public Guid? IdMat {get; private set;}
    public Informacion? DescAjt {get; private set;}
    public DateTime? FecDil {get; private set;}
    public static Ajuste Crear(
        Guid idMat,
        Informacion descAjt,
        DateTime fecDil
    )
    {
        var ajuste = new Ajuste(
            Guid.NewGuid(),
            idMat,
            descAjt,
            fecDil
        );

        ajuste.RaiseDomainEvent(new AjusteCreadoDomainEvent(ajuste.Id!));

        return ajuste;
    }

    public void Update(
        Informacion descAjt
    )
    {
        DescAjt = descAjt;
    }
}