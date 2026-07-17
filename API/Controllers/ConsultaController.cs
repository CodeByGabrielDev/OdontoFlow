using Application.Agenda.Consultas.Commands.CancelarConsulta;
using Application.Agenda.Consultas.Commands.ConcluirConsulta;
using Application.Agenda.Consultas.Commands.ConfirmarConsulta;
using Application.Consultas.BuscarConsulta;
using Application.Consultas.CriarConsulta;
using Application.Consultas.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/consulta")]
public class ConsultaController : ControllerBase
{
    private readonly IMediator _mediatr;

    public ConsultaController(IMediator _mediatr)
    {
        this._mediatr = _mediatr;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterConsultaPorId(Guid id)
    {
        ConsultaDto consultaDto = await this._mediatr.Send(new ObterConsultaPorIdQuery(id));
        return Ok(consultaDto);
    }
    [HttpPost]
    public async Task<IActionResult> CriarConsulta([FromBody] CriarConsultaCommand criarConsultaCommand)
    {
        Guid id = await this._mediatr.Send(criarConsultaCommand);
        return Ok(id);
    }
    [HttpPut("{id}/cancelar")]
    public async Task<IActionResult> CancelarConsulta(Guid id)
    {
        Guid idSend = await this._mediatr.Send(new CancelarConsultaCommand(id));
        return Ok(idSend);
    }
    [HttpPut("{id}/confirmar")]
    public async Task<IActionResult> ConfirmarConsulta(Guid id)
    {
        Guid idSend = await this._mediatr.Send(new ConfirmarConsultaCommand(id));
        return Ok(idSend);
    }
    [HttpPut("{id}/concluir")]
    public async Task<IActionResult> ConcluirConsulta(Guid id)
    {
        Guid idSend = await this._mediatr.Send(new ConcluirConsultaCommand(id));
        return Ok(idSend);
    }
}