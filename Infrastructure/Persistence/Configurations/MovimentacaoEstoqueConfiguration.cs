using Domain.Entities.Estoque;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class MovimentacaoEstoqueConfiguration : IEntityTypeConfiguration<MovimentacaoEstoque>
{
    public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
    {
        builder.ToTable("MovimentacaoEstoque");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidade => entidade.ItemEstoque)
               .WithMany()
               .HasForeignKey(entidade => entidade.ItemEstoqueId)
               .IsRequired();
        builder.Property(entidade => entidade.Tipo).IsRequired();
        builder.Property(entidade => entidade.Quantidade).IsRequired();
        builder.Property(entidade => entidade.Observacao).HasMaxLength(500);
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
