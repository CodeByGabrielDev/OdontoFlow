using Application.Agenda.GradeHorario.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Agenda.GradeHorario.Queries.ObterGradeHorarioPorDentistaId;

public class ObterGradeHorarioPorDentistaIdHandler
: IRequestHandler<ObterGradeHorarioPorDentistaIdQuery, List<GradeHorarioDto>>
{
    private readonly IGradeHorarioRepository _gradeHorarioRepository;

    public ObterGradeHorarioPorDentistaIdHandler(IGradeHorarioRepository _gradeHorarioRepository)
    {
        this._gradeHorarioRepository = _gradeHorarioRepository;
    }

    public async Task<List<GradeHorarioDto>> Handle(ObterGradeHorarioPorDentistaIdQuery obterGradeHorarioPorDentistaIdQuery, CancellationToken cancellationToken)
    {
        List<GradeHorarioDto> gradeHorarioDtos = new List<GradeHorarioDto>();

        List<Domain.Entities.Agenda.GradeHorario> gradeHorarios = await this._gradeHorarioRepository.BuscarGradePorDentistaId(obterGradeHorarioPorDentistaIdQuery.IdDentista);

        foreach (Domain.Entities.Agenda.GradeHorario grade in gradeHorarios)
        {
            gradeHorarioDtos.Add(new GradeHorarioDto(grade.Id, grade.DiaSemana.ToString(), grade.HoraInicio, grade.HoraFim, grade.Ativo));
        }
        return gradeHorarioDtos;
    }

}