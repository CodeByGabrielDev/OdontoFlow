using Application.Agenda.GradeHorario.DTOs;
using MediatR;

namespace Application.Agenda.GradeHorario.Queries.ObterGradeHorarioPorId;

public record ObterGradeHorarioPorIdQuery(Guid Id) : IRequest<GradeHorarioDto>;