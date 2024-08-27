using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Evaluaciones;
using PiarServer.Domain.Materias;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class EvaluacionConfiguration : IEntityTypeConfiguration<Evaluacion>
{
    public void Configure(EntityTypeBuilder<Evaluacion> builder)
    {
        builder.ToTable("evaluaciones");
        builder.HasKey( evaluacion => evaluacion.Id );

        builder.Property( evaluacion => evaluacion.DescEva )
            .HasMaxLength(500)
            .HasConversion( informacion => informacion!.DescEva, descEva => new Domain.Evaluaciones.Informacion(descEva) );

        builder.HasOne<Materia>()
            .WithMany()
            .HasForeignKey( evaluacion => evaluacion.IdMat );
    }
}