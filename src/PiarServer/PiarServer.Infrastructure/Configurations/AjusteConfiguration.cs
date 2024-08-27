using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Ajustes;
using PiarServer.Domain.Materias;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class AjusteConfiguration : IEntityTypeConfiguration<Ajuste>
{
    public void Configure(EntityTypeBuilder<Ajuste> builder)
    {
        builder.ToTable("ajustes");
        builder.HasKey(ajuste => ajuste.Id);

        builder.Property(ajuste => ajuste.DescAjt)
            .HasMaxLength(500)
            .HasConversion(informacion => informacion!.DescAjt, descAjt => new Domain.Ajustes.Informacion(descAjt));

        builder.HasOne<Materia>()
            .WithMany()
            .HasForeignKey( ajuste => ajuste.IdMat );
    }
}