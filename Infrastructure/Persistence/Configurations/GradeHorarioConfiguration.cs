using Domain.Entities.Agenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GradeHorarioConfiguration : IEntityTypeConfiguration<GradeHorario>
{
    public void Configure(EntityTypeBuilder<GradeHorario> builder)
    {
        builder.ToTable("Grade_horario");
        builder.HasKey(entidadeGrade => entidadeGrade.Id);
        builder.HasOne(entidadeGrade => entidadeGrade.Dentista)
               .WithMany(entidadeDentista => entidadeDentista.GradeHorarios)
               .HasForeignKey(entidadeGrade => entidadeGrade.DentistaId)
               .IsRequired();
        builder.Property(entidadeGrade=>entidadeGrade.DiaSemana).IsRequired().HasColumnName("dia_semana");
        builder.Property(entidadeGrade=>entidadeGrade.HoraInicio).IsRequired().HasColumnName("hora_inicio");
        builder.Property(entidadeGrade=>entidadeGrade.HoraFim).IsRequired().HasColumnName("hora_fim");
        builder.Property(entidadeGrade=>entidadeGrade.Ativo);
    }
}