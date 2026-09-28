using Domain.Entities.Convenios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PacienteConvenioConfiguration : IEntityTypeConfiguration<PacienteConvenio>
{
    public void Configure(EntityTypeBuilder<PacienteConvenio> builder)
    {
        builder.ToTable("PacienteConvenio");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidade => entidade.Paciente)
               .WithMany()
               .HasForeignKey(entidade => entidade.PacienteId)
               .IsRequired();
        builder.HasOne(entidade => entidade.Convenio)
               .WithMany()
               .HasForeignKey(entidade => entidade.ConvenioId)
               .IsRequired();
        builder.Property(entidade => entidade.NumeroCarteirinha).IsRequired().HasMaxLength(50);
        builder.Property(entidade => entidade.Validade).IsRequired();
    }
}
