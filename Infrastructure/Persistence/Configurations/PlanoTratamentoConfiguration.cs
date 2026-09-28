using Domain.Entities.Prontuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PlanoTratamentoConfiguration : IEntityTypeConfiguration<PlanoTratamento>
{
    public void Configure(EntityTypeBuilder<PlanoTratamento> builder)
    {
        builder.ToTable("PlanoTratamento");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidade => entidade.Prontuario)
               .WithMany(prontuario => prontuario.PlanosTratamento)
               .HasForeignKey(entidade => entidade.ProntuarioId)
               .IsRequired();
        builder.HasOne(entidade => entidade.Dentista)
               .WithMany()
               .HasForeignKey(entidade => entidade.DentistaId)
               .IsRequired();
        builder.Property(entidade => entidade.Descricao).IsRequired();
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
