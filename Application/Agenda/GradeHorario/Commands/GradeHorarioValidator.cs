using FluentValidation;

namespace Application.Agenda.GradeHorario.Commands;

public class GradeHorarioValidator : AbstractValidator<GradeHorarioCommand>
{
    public GradeHorarioValidator()
    {
        RuleFor(entidadeGrade=>entidadeGrade.IdDentista).NotEmpty();
        RuleFor(entidadeGrade=>entidadeGrade.DiaSemana).NotEmpty();
        RuleFor(entidadeGrade=>entidadeGrade.HoraInicio).NotEmpty();
        RuleFor(entidadeGrade=>entidadeGrade.HoraFim).NotEmpty();
    }
}