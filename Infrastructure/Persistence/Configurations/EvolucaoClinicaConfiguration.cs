using Domain.Entities.Prontuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


public class EvolucaoClinicaConfiguration : IEntityTypeConfiguration<EvolucaoClinica>
{
    /*public Guid Id{get;private set;}
    public Guid ProntuarioId{get;private set;}
    public Prontuario Prontuario{get;private set;}
    public Guid DentistaId{get;private set;}
    public Dentista Dentista{get;private set;}
    public Guid ConsultaId{get;private set;}
    public Consulta Consulta{get;private set;}
    public string Descricao{get;private set;}
    public DateTime CriadoEm{get;private set;}*/
    public void Configure(EntityTypeBuilder<EvolucaoClinica> builder)
    {
        builder.ToTable("Evolucao_clinica");
        builder.HasKey(entidadeEvolucaoClinica=>entidadeEvolucaoClinica.Id);
        builder.HasOne(entidadeEvolucaoCLinica=>entidadeEvolucaoCLinica.Prontuario)
               .WithMany(entidadeProntuario=>entidadeProntuario.EvolucaoClinicas)
               .HasForeignKey(entidadeEvolucaoClinica=>entidadeEvolucaoClinica.ProntuarioId)
               .IsRequired();
        builder.HasOne(entidadeEvolucaoClinica=>entidadeEvolucaoClinica.Dentista)
               .WithMany(entidadeDentista=>entidadeDentista.EvolucaoClinicas)
               .HasForeignKey(entidadeEvolucaoCLinica=>entidadeEvolucaoCLinica.DentistaId)
               .IsRequired();
        builder.HasOne(entidadeEvolucaoClinica=>entidadeEvolucaoClinica.Consulta)
               .WithMany(entidadeConsulta=>entidadeConsulta.evolucaoClinicas)
               .HasForeignKey(entidadeEvolucaoClinica=>entidadeEvolucaoClinica.ConsultaId)
               .IsRequired();
        builder.Property(entidadeEvolucaoClinica=>entidadeEvolucaoClinica.Descricao);
        builder.Property(entidadeEvolucaoClinica=>entidadeEvolucaoClinica.CriadoEm).HasColumnName("Criado_em");
        
    }
}