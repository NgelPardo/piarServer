using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Barreras;
using PiarServer.Domain.BarrerasPiar;
using PiarServer.Domain.MateriasPiar;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class BarreraPiarConfiguration : IEntityTypeConfiguration<BarreraPiar>
{
    public void Configure(EntityTypeBuilder<BarreraPiar> builder)
    {
        builder.ToTable("barreras_piar");
        builder.HasKey( barreraPiar => barreraPiar.Id );

        builder.Property( barreraPiar => barreraPiar.SemBarr )
            .HasMaxLength(200)
            .HasConversion( ubicacion => ubicacion!.SemBarr, semBarr => new Ubicacion(semBarr) );

        builder.HasOne<Barrera>()
            .WithMany()
            .HasForeignKey( barreraPiar => barreraPiar.IdBarr ); 

        builder.HasOne<MateriaPiar>()
            .WithMany()
            .HasForeignKey( barreraPiar => barreraPiar.IdMat )
            .OnDelete(DeleteBehavior.Cascade);
    }
}
