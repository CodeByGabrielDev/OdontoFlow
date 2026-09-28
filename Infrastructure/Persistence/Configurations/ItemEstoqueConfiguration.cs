using Domain.Entities.Estoque;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ItemEstoqueConfiguration : IEntityTypeConfiguration<ItemEstoque>
{
    public void Configure(EntityTypeBuilder<ItemEstoque> builder)
    {
        builder.ToTable("ItemEstoque");
        builder.HasKey(entidade => entidade.Id);
        builder.Property(entidade => entidade.Nome).IsRequired().HasMaxLength(200);
        builder.Property(entidade => entidade.Descricao).HasMaxLength(500);
        builder.Property(entidade => entidade.QuantidadeAtual).IsRequired();
        builder.Property(entidade => entidade.QuantidadeMinima).IsRequired();
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
