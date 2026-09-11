using Application.Prontuarios.Command.EvolucaoClinicaCommand;
using Application.Prontuarios.DTOs;
using Application.Prontuarios.Queries.ObterProntuarioPorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Authorize]
[ApiController]
[Route("api/prontuarios")]
public class ProntuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProntuarioController(IMediator _mediator)
    {
        this._mediator = _mediator;
    }
    [HttpGet("{idProntuario}")]
    public async Task<IActionResult> ObterProntuarioPorId(Guid idProntuario)
    {
        ProntuarioDto prontuarioDto = await this._mediator.Send(new ObterProntuarioPorIdQuery(idProntuario));
        return Ok(prontuarioDto);
    }

    [HttpPost("/evolucaoClinicaApi")]
    public async Task<IActionResult> AdicionarEvolucaoClinica([FromBody] EvolucaoClinicaCommand evolucaoClinicaCommand)
    {
        Guid Id = await this._mediator.Send(evolucaoClinicaCommand);
        return Ok(Id);
    }
}