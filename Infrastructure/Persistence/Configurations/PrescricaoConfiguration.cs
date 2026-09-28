using Domain.Entities.Prontuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PrescricaoConfiguration : IEntityTypeConfiguration<Prescricao>
{
    public void Configure(EntityTypeBuilder<Prescricao> builder)
    {
        builder.ToTable("Prescricao");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidade => entidade.Prontuario)
               .WithMany(prontuario => prontuario.Prescricoes)
               .HasForeignKey(entidade => entidade.ProntuarioId)
               .IsRequired();
        builder.HasOne(entidade => entidade.Dentista)
               .WithMany()
               .HasForeignKey(entidade => entidade.DentistaId)
               .IsRequired();
        builder.Property(entidade => entidade.Medicamentos).IsRequired();
        builder.Property(entidade => entidade.Instrucoes);
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
