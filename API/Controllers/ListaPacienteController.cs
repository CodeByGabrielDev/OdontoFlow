using Application.Agenda.ListaEspera.Commands.CriarListaDeEspera;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/lista-espera")]
public class ListaPacienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ListaPacienteController(IMediator _mediator)
    {
        this._mediator = _mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CriarListaDeEspera([FromBody] CriarListaDeEsperaCommand criarListaDeEsperaCommand)
    {
        Guid id = await this._mediator.Send(criarListaDeEsperaCommand);
        return Ok(id);
    }
}