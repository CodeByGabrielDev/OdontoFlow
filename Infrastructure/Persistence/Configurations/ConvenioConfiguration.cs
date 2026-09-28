using Domain.Entities.Convenios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ConvenioConfiguration : IEntityTypeConfiguration<Convenio>
{
    public void Configure(EntityTypeBuilder<Convenio> builder)
    {
        builder.ToTable("Convenio");
        builder.HasKey(entidade => entidade.Id);
        builder.Property(entidade => entidade.Nome).IsRequired().HasMaxLength(200);
        builder.Property(entidade => entidade.Operadora).IsRequired().HasMaxLength(200);
        builder.Property(entidade => entidade.Ativo).IsRequired();
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
