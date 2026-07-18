using Domain.Entities.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(entidadeUsuario => entidadeUsuario.Id);
        builder.Property(entidadeUsuario => entidadeUsuario.Nome).IsRequired();
        builder.OwnsOne(entidadeUsuario => entidadeUsuario.Email, email =>
        {
            email.Property(email => email.Valor).IsRequired();
        });
        builder.Property(entidadeUsuario => entidadeUsuario.SenhaHash).IsRequired();
        builder.Property(entidadeUsuario => entidadeUsuario.Perfil).HasConversion<string>().IsRequired();
        builder.Property(entidadeUsuario => entidadeUsuario.Ativo).IsRequired();
        builder.Property(entidadeUsuario => entidadeUsuario.CriadoEm).IsRequired();
    }
}