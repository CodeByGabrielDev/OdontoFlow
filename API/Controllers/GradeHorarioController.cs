using Application.Agenda.GradeHorario.Commands;
using Application.Agenda.GradeHorario.DTOs;
using Application.Agenda.GradeHorario.Queries.ObterGradeHorarioPorDentistaId;
using Application.Agenda.GradeHorario.Queries.ObterGradeHorarioPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/grade-horario")]
public class GradeHorarioController : ControllerBase
{
    private readonly IMediator _mediatR;

    public GradeHorarioController(IMediator _mediatR)
    {
        this._mediatR = _mediatR;
    }
    [HttpPost("{idDentista}")]
    public async Task<IActionResult> CriarGradeHorario(Guid idDentista, [FromBody] GradeHorarioCommand gradeHorarioCommand)
    {
        Guid id = await this._mediatR.Send(gradeHorarioCommand with { IdDentista = idDentista });
        return Ok(id);
    }
    [HttpGet("{idGrade}/detalhe")]
    public async Task<IActionResult> ObterGradeHorarioPorId(Guid idGrade)
    {
        GradeHorarioDto gradeHorarioDto = await this._mediatR.Send(new ObterGradeHorarioPorIdQuery(idGrade));
        return Ok(gradeHorarioDto);
    }
    [HttpGet("{idDentista}")]
    public async Task<IActionResult> ObterGradeHorarioPorDentistaId(Guid idDentista)
    {
        List<GradeHorarioDto> gradeHorarioDtos = await this._mediatR.Send(new ObterGradeHorarioPorDentistaIdQuery(idDentista));
        return Ok(gradeHorarioDtos);
    }


}