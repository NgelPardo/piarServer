using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.MateriasPiar;
using PiarServer.Domain.Piars;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class MateriaPiarConfiguration : IEntityTypeConfiguration<MateriaPiar>
{
    public void Configure(EntityTypeBuilder<MateriaPiar> builder)
    {
        builder.ToTable("materias_piar");
        builder.HasKey( materiaPiar => materiaPiar.Id );

        builder.Property( materiaPiar => materiaPiar.Materia )
            .HasMaxLength(200)
            .HasConversion( materia => materia!.SemMat, semMat => new Materia(semMat) );

        builder.HasOne<Domain.Materias.Materia>()
            .WithMany()
            .HasForeignKey( materiaPiar => materiaPiar.IdMat );
        
        builder.HasOne<Piar>()
            .WithMany()
            .HasForeignKey( materiaPiar => materiaPiar.IdPiar );
    }
}