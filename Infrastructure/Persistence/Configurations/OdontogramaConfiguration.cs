using Domain.Entities.Prontuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class OdontogramaConfiguration : IEntityTypeConfiguration<Odontograma>
{
    public void Configure(EntityTypeBuilder<Odontograma>builder)
    {
        builder.ToTable("Odontograma");
        builder.HasKey(x=>x.Id);
        builder.HasOne(x=>x.Prontuario)
               .WithOne(y=>y.Odontograma)
               .HasForeignKey<Odontograma>(o => o.ProntuarioId);
        
    }
}