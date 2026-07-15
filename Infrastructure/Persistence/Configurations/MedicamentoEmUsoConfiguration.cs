using Domain.Entities.Pacientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class MedicamentoEmUsoConfiguration : IEntityTypeConfiguration<MedicamentoEmUso>
{
    public void Configure(EntityTypeBuilder<MedicamentoEmUso> builder)
    {
        builder.ToTable("medicamentos_em_uso");
        builder.HasKey(entidadeMedicamento => entidadeMedicamento.Id);
        builder.HasOne(entidadeMedicamento => entidadeMedicamento.Anamnese)
               .WithMany(entidadeAnamnese => entidadeAnamnese.MedicamentoEmUso)
               .HasForeignKey(entidadeMedicamento => entidadeMedicamento.AnamneseId)
               .IsRequired();
        builder.Property(entidadeMecicamento=>entidadeMecicamento.Descricao).IsRequired();
    }
}