using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Ajustes;
using PiarServer.Domain.AjustesPiar;
using PiarServer.Domain.MateriasPiar;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class AjustePiarConfiguration : IEntityTypeConfiguration<AjustePiar>
{
    public void Configure(EntityTypeBuilder<AjustePiar> builder)
    {
        builder.ToTable("ajustes_piar");
        builder.HasKey( ajustePiar => ajustePiar.Id );

        builder.Property( ajustePiar => ajustePiar.SemAjt )
            .HasMaxLength(200)
            .HasConversion( ubicacion => ubicacion!.SemAjt, semAjt => new Ubicacion(semAjt) );

        builder.HasOne<Ajuste>()
            .WithMany()
            .HasForeignKey( ajustePiar => ajustePiar.IdAjt );

        builder.HasOne<MateriaPiar>()
            .WithMany()
            .HasForeignKey( ajustePiar => ajustePiar.IdMat )
            .OnDelete(DeleteBehavior.Cascade);
    }
}