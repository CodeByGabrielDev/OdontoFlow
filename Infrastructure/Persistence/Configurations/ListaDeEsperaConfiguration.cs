using Domain.Entities.Agenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class ListaDeEsperaConfiguration : IEntityTypeConfiguration<ListaEspera>
{
    public void Configure(EntityTypeBuilder<ListaEspera> builder)
    {
        builder.ToTable("Lista_de_espera");
        builder.HasKey(entidadeLista => entidadeLista.Id);
        builder.HasOne(entidadeLista => entidadeLista.Dentista)
               .WithMany(entidadeDentista => entidadeDentista.ListaEsperas)
               .HasForeignKey(entidadeLista => entidadeLista.DentistaId)
               .IsRequired();
        builder.HasOne(entidadeLista => entidadeLista.Paciente)
               .WithMany(entidadePaciente => entidadePaciente.ListaEsperas)
               .HasForeignKey(entidadeLista => entidadeLista.PacienteId)
               .IsRequired();
        builder.Property(entidadeLista => entidadeLista.DataSolicitacao).IsRequired();
        builder.Property(entidadeLista => entidadeLista.Observacao).IsRequired(false);
    }
}