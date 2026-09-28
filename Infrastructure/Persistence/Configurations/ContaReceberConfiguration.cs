using Domain.Entities.Financeiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ContaReceberConfiguration : IEntityTypeConfiguration<ContaReceber>
{
    public void Configure(EntityTypeBuilder<ContaReceber> builder)
    {
        builder.ToTable("ContaReceber");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidade => entidade.Paciente)
               .WithMany()
               .HasForeignKey(entidade => entidade.PacienteId)
               .IsRequired();
        builder.HasOne(entidade => entidade.Orcamento)
               .WithMany()
               .HasForeignKey(entidade => entidade.OrcamentoId)
               .IsRequired();
        builder.Property(entidade => entidade.ValorTotal).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(entidade => entidade.ValorPago).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(entidade => entidade.Pago).IsRequired();
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
