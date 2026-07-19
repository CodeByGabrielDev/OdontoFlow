using MediatR;

namespace Application.Agenda.GradeHorario.Commands;


public record GradeHorarioCommand(Guid IdDentista,DayOfWeek DiaSemana,TimeSpan HoraInicio, TimeSpan HoraFim) : IRequest<Guid>;