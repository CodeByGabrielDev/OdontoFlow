using Domain.Entities.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("Funcionario");
        builder.HasKey(entidade => entidade.Id);
        builder.Property(entidade => entidade.Nome).IsRequired().HasMaxLength(200);
        builder.OwnsOne(entidade => entidade.Email, email =>
        {
            email.Property(e => e.Valor).IsRequired();
        });
        builder.OwnsOne(entidade => entidade.Telefone, telefone =>
        {
            telefone.Property(t => t.Valor).IsRequired().HasMaxLength(11);
        });
        builder.Property(entidade => entidade.Perfil).IsRequired();
        builder.Property(entidade => entidade.Ativo).IsRequired();
        builder.Property(entidade => entidade.CriadoEm).HasColumnName("Criado_em").IsRequired();
    }
}
