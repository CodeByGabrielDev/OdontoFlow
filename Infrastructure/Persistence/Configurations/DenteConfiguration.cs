using Domain.Entities.Prontuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class DenteConfiguration : IEntityTypeConfiguration<Dente>
{
    public void Configure(EntityTypeBuilder<Dente> builder)
    {
        builder.HasKey(Dente=>Dente.Id);
        builder.HasOne(dente=>dente.Odontograma)
               .WithMany(odontograma=>odontograma.Dentes)
               .HasForeignKey(dente=>dente.OdontogramaId)
               .IsRequired();
        builder.Property(dente=>dente.Numero).IsRequired();
        builder.HasIndex(dente => new { dente.OdontogramaId, dente.Numero }).IsUnique();
        builder.OwnsMany(dente => dente.StatusFaces, StatusFaces =>
        {
            StatusFaces.ToTable("DenteFace");
            StatusFaces.Property(faces=>faces.Face).IsRequired();
            StatusFaces.Property(faces=>faces.Status).IsRequired();
        });
    }
}