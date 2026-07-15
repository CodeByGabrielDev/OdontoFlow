using Domain.Entities.Agenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        builder.ToTable("Consultas");
        builder.HasKey(entidadeConsulta => entidadeConsulta.Id);
        builder.HasOne(entidadeConsulta => entidadeConsulta.Paciente)
               .WithMany(entidadePaciente => entidadePaciente.Consultas)
               .HasForeignKey(entidadeConsulta => entidadeConsulta.PacienteId)
               .IsRequired();
        builder.HasOne(entidadeConsulta => entidadeConsulta.Dentista)
               .WithMany(entidadeDentista => entidadeDentista.Consultas)
               .HasForeignKey(entidadeConsulta => entidadeConsulta.DentistaId)
               .IsRequired();
        builder.Property(entidadeConsulta => entidadeConsulta.Data).IsRequired();
        builder.Property(entidadeConsulta => entidadeConsulta.HoraInicio).IsRequired();
        builder.Property(entidadeConsulta => entidadeConsulta.HoraFim).IsRequired();
        builder.Property(entidadeConsulta => entidadeConsulta.StatusConsulta).HasConversion<string>().IsRequired();
        builder.Property(entidadeConsulta => entidadeConsulta.Observacao).IsRequired(false);
        builder.Property(entidadeConsulta => entidadeConsulta.CriadoEm).IsRequired();

    }
}