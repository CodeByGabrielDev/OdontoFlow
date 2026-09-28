using Application.Estoque.DTOs;
using Application.Estoque.Itens.Commands.CriarItemEstoque;
using Application.Estoque.Itens.Queries.ListarItens;
using Application.Estoque.Itens.Queries.ListarItensAbaixoMinimo;
using Application.Estoque.Movimentacoes.Commands.RegistrarMovimentacao;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/estoque")]
public class EstoqueController : ControllerBase
{
    private readonly IMediator _mediator;

    public EstoqueController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet("itens")]
    public async Task<IActionResult> ListarItens()
    {
        List<ItemEstoqueDto> itens = await this._mediator.Send(new ListarItensQuery());
        return Ok(itens);
    }

    [HttpGet("itens/abaixo-minimo")]
    public async Task<IActionResult> ListarItensAbaixoMinimo()
    {
        List<ItemEstoqueDto> itens = await this._mediator.Send(new ListarItensAbaixoMinimoQuery());
        return Ok(itens);
    }

    [HttpPost("itens")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)}")]
    public async Task<IActionResult> CriarItemEstoque([FromBody] CriarItemEstoqueCommand criarItemEstoqueCommand)
    {
        Guid id = await this._mediator.Send(criarItemEstoqueCommand);
        return Ok(id);
    }

    [HttpPost("itens/{idItemEstoque}/movimentacoes")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)}")]
    public async Task<IActionResult> RegistrarMovimentacao(Guid idItemEstoque, [FromBody] RegistrarMovimentacaoCommand registrarMovimentacaoCommand)
    {
        Guid id = await this._mediator.Send(registrarMovimentacaoCommand with { ItemEstoqueId = idItemEstoque });
        return Ok(id);
    }
}
