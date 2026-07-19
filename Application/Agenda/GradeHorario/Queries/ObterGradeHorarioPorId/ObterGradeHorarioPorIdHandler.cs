using Application.Agenda.GradeHorario.DTOs;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Agenda.GradeHorario.Queries.ObterGradeHorarioPorId;

public class ObterGradeHorarioPorIdHandler : IRequestHandler<ObterGradeHorarioPorIdQuery, GradeHorarioDto>
{
    private readonly IGradeHorarioRepository _gradeHorarioRepository;

    public ObterGradeHorarioPorIdHandler(IGradeHorarioRepository _gradeHorarioRepository)
    {
        this._gradeHorarioRepository = _gradeHorarioRepository;
    }
    public async Task<GradeHorarioDto> Handle(ObterGradeHorarioPorIdQuery obterGradeHorarioPorIdQuery, CancellationToken cancellationToken)
    {
        Domain.Entities.Agenda.GradeHorario gradeHorario = await this._gradeHorarioRepository.BuscarGradePorId(obterGradeHorarioPorIdQuery.Id);
        if (gradeHorario == null)
        {
            throw new DomainException("Grade horario inexistnete na base de dados");
        }
        return new GradeHorarioDto(gradeHorario.Id, gradeHorario.DiaSemana.ToString(), gradeHorario.HoraInicio, gradeHorario.HoraFim, gradeHorario.Ativo);
    }
}