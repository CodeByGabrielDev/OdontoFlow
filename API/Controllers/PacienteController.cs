using Application.Pacientes.Commands.AtualizarPaciente;
using Application.Pacientes.Commands.CadastrarPaciente;
using Application.Pacientes.DTOs;
using Application.Pacientes.Queries.ListarPacientes;
using Application.Pacientes.Queries.ObterPacientePorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/pacientes")]
public class PacienteController:ControllerBase
{
    private readonly IMediator _mediator;

    public PacienteController(IMediator _mediator)
    {
        this._mediator = _mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody]CadastrarPacienteCommand pacienteCommand)
    {
        Guid Id = await this._mediator.Send(pacienteCommand);
        return Ok(new {Id});
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id,[FromBody] AtualizarPacienteCommand atualizarPacienteCommand)
    {
        await this._mediator.Send(atualizarPacienteCommand with {Id = id});
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        PacienteDto pacienteDto = await this._mediator.Send(new ObterPacienteQuery(id));
        return Ok(pacienteDto);
    }
    [HttpGet("filter")]
    public async Task<IActionResult> Listar([FromQuery] string? nome,[FromQuery]string? cpf)
    {
        IEnumerable<PacienteResumoDto> pacienteDtos = await this._mediator.Send(new ListarPacientesQuery(nome,cpf));
        return Ok(pacienteDtos);
    }

}