using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Evaluaciones;
using PiarServer.Domain.EvaluacionesPiar;
using PiarServer.Domain.MateriasPiar;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class EvaluacionPiarConfiguration : IEntityTypeConfiguration<EvaluacionPiar>
{
    public void Configure(EntityTypeBuilder<EvaluacionPiar> builder)
    {
        builder.ToTable("evaluaciones_piar");
        builder.HasKey( evaluacionPiar => evaluacionPiar.Id );

        builder.Property( evaluacionPiar => evaluacionPiar.SemEva )
            .HasMaxLength(200)
            .HasConversion( ubicacion => ubicacion!.SemEva, semEva => new Ubicacion(semEva) );

        builder.HasOne<Evaluacion>()
            .WithMany()
            .HasForeignKey( evaluacionPiar => evaluacionPiar.IdEva );

        builder.HasOne<MateriaPiar>()
            .WithMany()
            .HasForeignKey( evaluacionPiar => evaluacionPiar.IdMat )
            .OnDelete(DeleteBehavior.Cascade);
    }
}