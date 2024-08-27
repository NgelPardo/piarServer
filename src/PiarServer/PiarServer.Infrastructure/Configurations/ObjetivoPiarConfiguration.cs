using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.MateriasPiar;
using PiarServer.Domain.Objetivos;
using PiarServer.Domain.ObjetivosPiar;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class ObjetivoPiarConfiguration : IEntityTypeConfiguration<ObjetivoPiar>
{
    public void Configure(EntityTypeBuilder<ObjetivoPiar> builder)
    {
        builder.ToTable("objetivos_piar");
        builder.HasKey( objetivoPiar => objetivoPiar.Id );

        builder.Property( objetivoPiar => objetivoPiar.SemObj )
            .HasMaxLength(200)
            .HasConversion( ubicacion => ubicacion!.SemObj, semObj => new Ubicacion(semObj) );

        builder.HasOne<Objetivo>()
            .WithMany()
            .HasForeignKey( objetivoPiar => objetivoPiar.IdObj );

        builder.HasOne<MateriaPiar>()
            .WithMany()
            .HasForeignKey( objetivoPiar => objetivoPiar.IdMat )
            .OnDelete(DeleteBehavior.Cascade);
    }
}