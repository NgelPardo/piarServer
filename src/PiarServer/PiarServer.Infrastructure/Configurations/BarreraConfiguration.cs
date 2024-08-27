using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Barreras;
using PiarServer.Domain.Materias;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class BarreraConfiguration : IEntityTypeConfiguration<Barrera>
{
    public void Configure(EntityTypeBuilder<Barrera> builder)
    {
        builder.ToTable("barreras");
        builder.HasKey( barrera => barrera.Id );

        builder.Property( barrera => barrera.DescBarr )
            .HasMaxLength(500)
            .HasConversion( informacion => informacion!.DescBarr, descBarr => new Domain.Barreras.Informacion(descBarr) );

        builder.HasOne<Materia>()
            .WithMany()
            .HasForeignKey( barrera => barrera.IdMat );
    }
}