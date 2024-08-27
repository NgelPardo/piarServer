using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Piars.Events;

namespace PiarServer.Domain.Piars;
public sealed class Piar : Entity
{
    private Piar(){}
    private Piar(
        Guid id,
        Guid idUss,
        PiarStatus estPiar,
        Guid idEst,
        Guid idProf,
        DiligenciamientoUno diligenciamientoUno,
        Estudiante estudiante,
        Salud salud,
        Hogar hogar,
        Educativo educativo,
        DiligenciamientoDos diligenciamientoDos,
        CaracteristicasEstudiante caracteristicasEstudiante,
        Recomendaciones recomendaciones,
        DiligenciamientoTres diligenciamientoTres
        ) : base(id)
    {
        IdUss = idUss;
        EstPiar = estPiar;
        IdEst = idEst;
        IdProf = idProf;
        DiligenciamientoUno = diligenciamientoUno;
        Estudiante = estudiante;
        Salud = salud;
        Hogar = hogar;
        Educativo = educativo;
        DiligenciamientoDos = diligenciamientoDos;
        CaracteristicasEstudiante = caracteristicasEstudiante;
        Recomendaciones = recomendaciones;
        DiligenciamientoTres = diligenciamientoTres;
    }
    private Piar(
            Guid id,
            Guid idUss,
            PiarStatus estPiar,
            Guid idEst,
            Guid idProf,
            DiligenciamientoUno diligenciamientoUno,
            Estudiante estudiante,
            Salud salud,
            Hogar hogar,
            Educativo educativo
        ) : base(id)
    {
        IdUss = idUss;
        EstPiar = estPiar;
        IdEst = idEst;
        IdProf = idProf;
        DiligenciamientoUno = diligenciamientoUno;
        Estudiante = estudiante;
        Salud = salud;
        Hogar = hogar;
        Educativo = educativo;
    }
    public Guid IdUss {get; private set;}
    public PiarStatus EstPiar {get; private set;}
    public Guid IdEst {get; private set;}
    public Guid IdProf {get; private set;}
    public DiligenciamientoUno? DiligenciamientoUno {get; private set;}
    public Estudiante? Estudiante {get; private set;}
    public Salud? Salud {get; private set;}
    public Hogar? Hogar {get; private set;}
    public Educativo? Educativo {get; private set;}
    public DiligenciamientoDos? DiligenciamientoDos {get; private set;}
    public CaracteristicasEstudiante? CaracteristicasEstudiante {get; private set;}
    public Recomendaciones? Recomendaciones {get; private set;}
    public DiligenciamientoTres? DiligenciamientoTres {get; private set;}

    public static Piar Crear(
        Guid idUss,
        Guid idEst,
        Guid idProf,
        DiligenciamientoUno diligenciamientoUno,
        Estudiante estudiante,
        Salud salud,
        Hogar hogar,
        Educativo educativo,
        DiligenciamientoDos diligenciamientoDos,
        CaracteristicasEstudiante caracteristicasEstudiante,
        Recomendaciones recomendaciones,
        DiligenciamientoTres diligenciamientoTres
    )
    {
        var piar = new Piar(
            Guid.NewGuid(),
            idUss,
            PiarStatus.Pendiente,
            Guid.NewGuid(),
            idProf,
            diligenciamientoUno,
            estudiante,
            salud,
            hogar,
            educativo,
            diligenciamientoDos,
            caracteristicasEstudiante,
            recomendaciones,
            diligenciamientoTres
        );

        piar.RaiseDomainEvent(new PiarCreadoDomainEvent(piar.Id!));

        return piar;
    }

    public static Piar CrearPrimeraParte(
        Guid idUss,
        Guid idEst,
        Guid idProf,
        DiligenciamientoUno diligenciamientoUno,
        Estudiante estudiante,
        Salud salud,
        Hogar hogar,
        Educativo educativo
    )
    {
        var piar = new Piar(
            Guid.NewGuid(),
            idUss,
            PiarStatus.Pendiente,
            idEst,
            idProf,
            diligenciamientoUno,
            estudiante,
            salud,
            hogar,
            educativo
        );

        piar.RaiseDomainEvent(new PiarCreadoDomainEvent(piar.Id!));

        return piar;
    }

    public void UpdatePt1(
        Guid idUss,
        Guid idEst,
        Guid idProf,
        DiligenciamientoUno diligenciamientoUno,
        Estudiante estudiante,
        Salud salud,
        Hogar hogar,
        Educativo educativo
    )
    {
        IdUss = idUss;
        IdEst = idEst;
        IdProf = idProf;
        DiligenciamientoUno = diligenciamientoUno;
        Estudiante = estudiante;
        Salud = salud;
        Hogar = hogar;
        Educativo = educativo; 
    }
    public void UpdatePt2(
        DiligenciamientoDos diligenciamientoDos,
        CaracteristicasEstudiante caracteristicasEstudiante
    )
    {
        DiligenciamientoDos = diligenciamientoDos;
        CaracteristicasEstudiante = caracteristicasEstudiante;
    }

    public void UpdatePt3(
        Recomendaciones recomendaciones
    )
    {
        Recomendaciones = recomendaciones;
    }

    public void UpdatePt4(
        DiligenciamientoTres diligenciamientoTres
    )
    {
        DiligenciamientoTres = diligenciamientoTres;
    }
}
