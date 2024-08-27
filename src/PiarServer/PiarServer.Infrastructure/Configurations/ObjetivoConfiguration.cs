using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Materias;
using PiarServer.Domain.Objetivos;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class ObjetivoConfiguration : IEntityTypeConfiguration<Objetivo>
{
    public void Configure(EntityTypeBuilder<Objetivo> builder)
    {
        builder.ToTable("objetivos");
        builder.HasKey(objetivo => objetivo.Id);

        builder.Property(objetivo => objetivo.DescObj)
            .HasMaxLength(500)
            .HasConversion(
                informacion => informacion!.DescObj,
                descObj => new Domain.Objetivos.Informacion(descObj)
            );

        builder.HasOne<Materia>()
            .WithMany()
            .HasForeignKey(objetivo => objetivo.IdMat);
    }
}