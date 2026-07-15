using Domain.Entities.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DentistaConfiguration : IEntityTypeConfiguration<Dentista>
{
    public void Configure(EntityTypeBuilder<Dentista> builder)
    {
        builder.ToTable("Dentistas");
        builder.HasKey(entidadeDentista => entidadeDentista.Id);
        builder.OwnsOne(entidadeDentista => entidadeDentista.Cro, cro =>
        {
            cro.Property(Cro => Cro.Numero).HasColumnName("NumeroCro").IsRequired().HasMaxLength(10);
            cro.Property(Uf => Uf.Uf).HasColumnName("UfCro").IsRequired().HasMaxLength(2);
        });
        builder.OwnsOne(entidadeDentista => entidadeDentista.Email, email =>
        {
            email.Property(email => email.Valor).HasColumnName("email").IsRequired();
        });
        builder.OwnsOne(EntidadeDentista => EntidadeDentista.Telefone, telefone =>
        {
            telefone.Property(telefone => telefone.Valor).IsRequired();
        });
        builder.Property(entidadeDentista => entidadeDentista.Especialidade).IsRequired();
        builder.Property(entidadeDentista => entidadeDentista.Ativo).IsRequired();
        builder.Property(entidadeDentista => entidadeDentista.CriadoEm).IsRequired();
    }
}