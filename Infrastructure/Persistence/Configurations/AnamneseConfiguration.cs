using Domain.Entities.Pacientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AnamneseConfiguration : IEntityTypeConfiguration<Anamnese>
{
    public void Configure(EntityTypeBuilder<Anamnese> builder)
    {
        builder.ToTable("Anamneses");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.PreenchidaEm).IsRequired();

        builder.HasOne(a => a.Paciente)
               .WithOne()
               .HasForeignKey<Anamnese>(a => a.PacienteId)
               .IsRequired();
    }
}