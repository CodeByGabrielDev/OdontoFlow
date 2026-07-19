using Application.Agenda.GradeHorario.DTOs;
using MediatR;

namespace Application.Agenda.GradeHorario.Queries.ObterGradeHorarioPorDentistaId;

public record ObterGradeHorarioPorDentistaIdQuery(Guid IdDentista) : IRequest<List<GradeHorarioDto>>;