using Domain.Entities.Prontuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class ProntuarioConfiguration : IEntityTypeConfiguration<Prontuario>
{
    public void Configure(EntityTypeBuilder<Prontuario> builder)
    {
        builder.ToTable("Prontuario");
        builder.HasKey(prontuario => prontuario.Id);
        builder.Property(prontuario => prontuario.CriadoEm).HasColumnName("Criado_em").IsRequired();
        builder.HasOne(prontuario => prontuario.Paciente)
               .WithMany(paciente => paciente.Prontuarios)
               .HasForeignKey(prontuario => prontuario.PacienteId)
               .IsRequired();
    }
}