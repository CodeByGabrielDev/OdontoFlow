using Domain.Entities.Pacientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class DoencasSistemicasConfiguration : IEntityTypeConfiguration<DoencasSistemicas>
{
    
    public void Configure(EntityTypeBuilder<DoencasSistemicas> builder)
    {
        builder.ToTable("Doencas_sistemicas");
        builder.HasKey(entidade=>entidade.Id);
        builder.HasOne(entidade=>entidade.Anamnese)
               .WithMany(entidadeAnamnese=>entidadeAnamnese.DoencasSistemicas)
               .HasForeignKey(entidadeDoencas=>entidadeDoencas.AnamneseId)
               .IsRequired();
        builder.Property(entidade=>entidade.Descricao).IsRequired();
    }
}