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
    private readonly Mediator _mediatr;

    public ConsultaController(Mediator _mediatr)
    {
        this._mediatr = _mediatr;
    }
    [HttpGet]
    public async Task<IActionResult> ObterConsultaPorId(Guid Id)
    {
        ConsultaDto consultaDto = await this._mediatr.Send(new ObterConsultaPorIdQuery(Id));
        return Ok(consultaDto);
    }
    [HttpPost]
    public async Task<IActionResult> CriarConsulta([FromBody] CriarConsultaCommand criarConsultaCommand)
    {
        Guid id =  await this._mediatr.Send(criarConsultaCommand);
        return Ok(id);
    }
}