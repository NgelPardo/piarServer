using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Materias.Events;

namespace PiarServer.Domain.Materias;

public sealed class Materia : Entity
{
    private Materia(){}
    private Materia(
        Guid idMat,
        Guid idUss,
        Guid idProf,
        Informacion nomMat,
        DateTime? fecDil
        ) : base(idMat)
    {
        IdUss = idUss;
        IdProf = idProf;
        NomMat = nomMat;
        FecDil = fecDil;
    }
    public Guid IdUss {get; private set;}
    public Guid IdProf {get; private set;}
    public Informacion? NomMat {get; private set;}
    public DateTime? FecDil {get; private set;}

    public static Materia Crear(
        Guid idUss,
        Guid idProf,
        Informacion nomMat,
        DateTime? fecDil
    )
    {
        var materia = new Materia(
            Guid.NewGuid(),
            idUss,
            idProf,
            nomMat,
            fecDil
        );

        materia.RaiseDomainEvent(new MateriaCreadaDomainEvent(materia.Id!));

        return materia;
    }

    public void Update(
        Guid idProf, 
        Informacion nomMat
    )
    {
        IdProf = idProf;
        NomMat = nomMat;
    }
}