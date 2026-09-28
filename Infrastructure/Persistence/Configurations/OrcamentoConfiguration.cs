using Domain.Entities.Financeiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OrcamentoConfiguration : IEntityTypeConfiguration<Orcamento>
{
    public void Configure(EntityTypeBuilder<Orcamento> builder)
    {
        builder.ToTable("Orcamento");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidade => entidade.Paciente)
               .WithMany()
               .HasForeignKey(entidade => entidade.PacienteId)
               .IsRequired();
        builder.HasOne(entidade => entidade.Dentista)
               .WithMany()
               .HasForeignKey(entidade => entidade.DentistaId)
               .IsRequired();
        builder.Property(entidade => entidade.Descricao).IsRequired().HasMaxLength(500);
        builder.Property(entidade => entidade.ValorTotal).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(entidade => entidade.Assinado).IsRequired();
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
