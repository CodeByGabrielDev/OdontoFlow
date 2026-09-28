using Application.Financeiro.DTOs;
using Application.Financeiro.Procedimentos.Commands.CriarProcedimento;
using Application.Financeiro.Procedimentos.Queries.ListarProcedimentos;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/procedimentos")]
public class ProcedimentoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProcedimentoController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListarProcedimentos()
    {
        List<ProcedimentoDto> procedimentos = await this._mediator.Send(new ListarProcedimentosQuery());
        return Ok(procedimentos);
    }

    [HttpPost]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Financeiro)}")]
    public async Task<IActionResult> CriarProcedimento([FromBody] CriarProcedimentoCommand criarProcedimentoCommand)
    {
        Guid id = await this._mediator.Send(criarProcedimentoCommand);
        return Ok(id);
    }
}
