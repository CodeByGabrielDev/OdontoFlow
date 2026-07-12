using Domain.Entities.Pacientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class ResponsavelConfiguration : IEntityTypeConfiguration<Responsavel>
{
    public void Configure(EntityTypeBuilder<Responsavel> builder)
    {
        builder.ToTable("Responsavel");
        builder.HasKey(entidade=>entidade.Id);
        builder.Property(entidade=>entidade.Nome).IsRequired().HasMaxLength(200);
        builder.OwnsOne(entidade=> entidade.Cpf, cpf =>
        {
            cpf.Property(cpfEntidade=>cpfEntidade.Valor).IsRequired().HasColumnName("cpf").HasMaxLength(11);
        });
        builder.OwnsOne(entidadeResponsavel=>entidadeResponsavel.Telefone, telefone =>
        {
            telefone.Property(telefoneEntidade=>telefoneEntidade.Valor).IsRequired();
        });
        builder.Property(entidade=>entidade.Parentesco).IsRequired();
    }
}