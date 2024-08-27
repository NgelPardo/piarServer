using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Piars;
using PiarServer.Domain.Users;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class PiarConfiguration : IEntityTypeConfiguration<Piar>
{
    public void Configure(EntityTypeBuilder<Piar> builder)
    {
        builder.ToTable("piars");
        builder.HasKey( piar => piar.Id );

        builder.OwnsOne( piar => piar.DiligenciamientoUno );

        builder.OwnsOne( piar => piar.Estudiante );

        builder.OwnsOne( piar => piar.Salud );

        builder.OwnsOne( piar => piar.Hogar );

        builder.OwnsOne( piar => piar.Educativo );

        builder.OwnsOne( piar => piar.DiligenciamientoDos );

        builder.OwnsOne( piar => piar.CaracteristicasEstudiante );

        builder.OwnsOne( piar => piar.Recomendaciones );

        builder.OwnsOne( piar => piar.DiligenciamientoTres );

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey( piar => piar.IdUss );

        builder.Property<uint>("Version").IsRowVersion();
    }
}