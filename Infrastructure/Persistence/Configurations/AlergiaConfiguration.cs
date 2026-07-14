using Domain.Entities.Pacientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class AlergiaConfiguration : IEntityTypeConfiguration<Alergias>
{
    public void Configure(EntityTypeBuilder<Alergias> builder)
    {
        builder.ToTable("Alergias");
        builder.HasKey(entidade => entidade.Id);
        builder.HasOne(entidadeAlergia => entidadeAlergia.Anamnese)
               .WithMany(anamnese => anamnese.Alergias)
               .HasForeignKey(entidadeAlergia => entidadeAlergia.AnamneseId)
               .IsRequired();
        builder.Property(alergiaEntidade => alergiaEntidade.Descricao).IsRequired();
    }
}