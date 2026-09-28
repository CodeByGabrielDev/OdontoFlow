using Domain.Entities.Financeiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProcedimentoConfiguration : IEntityTypeConfiguration<Procedimento>
{
    public void Configure(EntityTypeBuilder<Procedimento> builder)
    {
        builder.ToTable("Procedimento");
        builder.HasKey(entidade => entidade.Id);
        builder.Property(entidade => entidade.Nome).IsRequired().HasMaxLength(200);
        builder.Property(entidade => entidade.Descricao).HasMaxLength(500);
        builder.Property(entidade => entidade.ValorBase).IsRequired().HasColumnType("decimal(18,2)");
    }
}
