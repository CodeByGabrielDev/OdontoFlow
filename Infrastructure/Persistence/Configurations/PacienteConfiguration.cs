using Domain.Entities.Pacientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(200);
        builder.OwnsOne(p => p.Cpf, cpf =>
        {
            cpf.Property(t => t.Valor).IsRequired().HasColumnName("Cpf").HasMaxLength(11);
            cpf.HasIndex(c=>c.Valor).IsUnique();
        });
        builder.OwnsOne(p => p.Email, email =>
        {
            email.Property(p => p.Valor).IsRequired();
        });
        builder.OwnsOne(p => p.Telefone, telefone =>
        {
            telefone.Property(p => p.Valor).IsRequired().HasMaxLength(11);
        });
        builder.Property(p => p.DataNascimento).HasColumnName("data_nascimento").IsRequired();
        builder.Property(p => p.Sexo).IsRequired();
        builder.Property(p => p.Endereco).IsRequired();
        builder.Property(p => p.Ativo).IsRequired();
        builder.Property(p => p.CriadoEm).IsRequired();
        builder.HasOne(p => p.Responsavel).WithMany(r => r.Pacientes).HasForeignKey(p => p.ResponsavelId).IsRequired(false);
    }
}