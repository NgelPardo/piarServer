using PiarServer.Domain.Abstractions;
using PiarServer.Domain.MateriasPiar.Events;

namespace PiarServer.Domain.MateriasPiar
{
    public sealed class MateriaPiar : Entity
    {
        private MateriaPiar(){}
        private MateriaPiar(
            Guid id,
            Guid idPiar,
            Guid idMat,
            Materia materia
            ) : base(id)
        {
            IdPiar = idPiar;
            IdMat = idMat;
            Materia = materia;
        }
        public Guid? IdPiar {get; private set;}
        public Guid? IdMat {get; private set;}
        public Materia? Materia {get; private set;}
        public static MateriaPiar Crear(
            Guid idPiar,
            Guid idMat,
            Materia materia
        )
        {
            var materiaPiar = new MateriaPiar(
                Guid.NewGuid(),
                idPiar,
                idMat,
                materia
            );

            materiaPiar.RaiseDomainEvent(new MateriaPiarCreadaDomainEvent(materiaPiar.Id!));

            return materiaPiar;
        }
    }
}