using Domain.Enums;
using MediatR;

namespace Application.Agenda.GradeHorario.Commands;


public record GradeHorarioCommand(Guid IdDentista,DiaSemana DiaSemana,TimeSpan HoraInicio, TimeSpan HoraFim) : IRequest<Guid>;