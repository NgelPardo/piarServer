using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiarServer.Domain.FirmasPiar;
using PiarServer.Domain.Piars;

namespace PiarServer.Infrastructure.Configurations;

internal sealed class FirmasPiarConfiguration : IEntityTypeConfiguration<FirmaPiar>
{
    public void Configure(EntityTypeBuilder<FirmaPiar> builder)
    {
        builder.ToTable("firmas_piar");
        builder.HasKey( firmaPiar => firmaPiar.Id );

        builder.OwnsOne( firmaPiar => firmaPiar.Firma );

        builder.HasOne<Piar>()
            .WithMany()
            .HasForeignKey( firmaPiar => firmaPiar.IdPiar );
    }
}