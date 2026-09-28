using Application.Funcionarios.Funcionario.Commands.CriarFuncionario;
using Application.Funcionarios.Funcionario.DTOs;
using Application.Funcionarios.Funcionario.Queries.ListarFuncionarios;
using Application.Funcionarios.Funcionario.Queries.ObterFuncionarioPorId;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Authorize(Roles = nameof(TipoPerfil.Admin))]
[Route("api/funcionarios")]
public class FuncionarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public FuncionarioController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListarFuncionarios()
    {
        List<FuncionarioDto> funcionarios = await this._mediator.Send(new ListarFuncionariosQuery());
        return Ok(funcionarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterFuncionarioPorId(Guid id)
    {
        FuncionarioDto funcionario = await this._mediator.Send(new ObterFuncionarioPorIdQuery(id));
        return Ok(funcionario);
    }

    [HttpPost]
    public async Task<IActionResult> CriarFuncionario([FromBody] CriarFuncionarioCommand criarFuncionarioCommand)
    {
        Guid id = await this._mediator.Send(criarFuncionarioCommand);
        return Ok(id);
    }
}
