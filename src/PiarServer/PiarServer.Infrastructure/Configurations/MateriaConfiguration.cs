using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.Materias;
using PiarServer.Domain.Users;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class MateriaConfiguration : IEntityTypeConfiguration<Materia>
{
    public void Configure(EntityTypeBuilder<Materia> builder)
    {
        builder.ToTable("materias");
        builder.HasKey( materia => materia.Id );

        builder.OwnsOne( materia => materia.NomMat );

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey( materia => materia.IdUss );
    }
}