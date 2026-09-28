using Domain.Entities.Financeiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ParcelaConfiguration : IEntityTypeConfiguration<Parcela>
{
    public void Configure(EntityTypeBuilder<Parcela> builder)
    {
        builder.ToTable("Parcela");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidade => entidade.ContaReceber)
               .WithMany(contaReceber => contaReceber.Parcelas)
               .HasForeignKey(entidade => entidade.ContaReceberId)
               .IsRequired();
        builder.Property(entidade => entidade.Numero).IsRequired();
        builder.Property(entidade => entidade.Valor).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(entidade => entidade.Vencimento).IsRequired();
        builder.Property(entidade => entidade.Pago).IsRequired();
        builder.HasIndex(entidade => new { entidade.ContaReceberId, entidade.Numero }).IsUnique();
    }
}
