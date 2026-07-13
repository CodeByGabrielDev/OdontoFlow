
using Domain.Entities.Pacientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Infrastructure.Persistence.Configurations;


public class AnamneseConfiguration : IEntityTypeConfiguration<Anamnese>
{
    public void Configure(EntityTypeBuilder<Anamnese> builder)
    {
        builder.ToTable("Anamnese");
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.Paciente).WithOne()
                                       .HasForeignKey<Anamnese>(anamnese => anamnese.PacienteId).IsRequired();
        builder.Property("Alergias");
        builder.Property("Medicamento_em_uso");
        builder.Property("Doencas_sistemicas");
        builder.Property("Preenchida_em");
    }
}