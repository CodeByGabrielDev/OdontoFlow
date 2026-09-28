using Domain.Entities.Convenios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GuiaAutorizacaoConfiguration : IEntityTypeConfiguration<GuiaAutorizacao>
{
    public void Configure(EntityTypeBuilder<GuiaAutorizacao> builder)
    {
        builder.ToTable("GuiaAutorizacao");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidade => entidade.Paciente)
               .WithMany()
               .HasForeignKey(entidade => entidade.PacienteId)
               .IsRequired();
        builder.HasOne(entidade => entidade.Convenio)
               .WithMany()
               .HasForeignKey(entidade => entidade.ConvenioId)
               .IsRequired();
        builder.HasOne(entidade => entidade.Procedimento)
               .WithMany()
               .HasForeignKey(entidade => entidade.ProcedimentoId)
               .IsRequired();
        builder.Property(entidade => entidade.Status).IsRequired();
        builder.Property(entidade => entidade.Observacao).HasMaxLength(500);
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
