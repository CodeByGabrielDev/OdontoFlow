using Application.Financeiro.ContasReceber.Commands.CriarContaReceber;
using Application.Financeiro.ContasReceber.Queries.ObterContaReceberPorId;
using Application.Financeiro.DTOs;
using Application.Financeiro.Orcamentos.Commands.AssinarOrcamento;
using Application.Financeiro.Orcamentos.Commands.CriarOrcamento;
using Application.Financeiro.Orcamentos.Queries.ObterOrcamentoPorId;
using Application.Financeiro.Parcelas.Commands.CriarParcela;
using Application.Financeiro.Parcelas.Commands.RegistrarPagamentoParcela;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/financeiro")]
public class FinanceiroController : ControllerBase
{
    private readonly IMediator _mediator;

    public FinanceiroController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpPost("orcamentos")]
    [Authorize(Roles = nameof(TipoPerfil.Dentista))]
    public async Task<IActionResult> CriarOrcamento([FromBody] CriarOrcamentoCommand criarOrcamentoCommand)
    {
        Guid id = await this._mediator.Send(criarOrcamentoCommand);
        return Ok(id);
    }

    [HttpGet("orcamentos/{id}")]
    public async Task<IActionResult> ObterOrcamentoPorId(Guid id)
    {
        OrcamentoDto orcamento = await this._mediator.Send(new ObterOrcamentoPorIdQuery(id));
        return Ok(orcamento);
    }

    [HttpPut("orcamentos/{id}/assinar")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)},{nameof(TipoPerfil.Financeiro)}")]
    public async Task<IActionResult> AssinarOrcamento(Guid id)
    {
        Guid orcamentoId = await this._mediator.Send(new AssinarOrcamentoCommand(id));
        return Ok(orcamentoId);
    }

    [HttpPost("contas-receber")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Financeiro)}")]
    public async Task<IActionResult> CriarContaReceber([FromBody] CriarContaReceberCommand criarContaReceberCommand)
    {
        Guid id = await this._mediator.Send(criarContaReceberCommand);
        return Ok(id);
    }

    [HttpGet("contas-receber/{id}")]
    public async Task<IActionResult> ObterContaReceberPorId(Guid id)
    {
        ContaReceberDto contaReceber = await this._mediator.Send(new ObterContaReceberPorIdQuery(id));
        return Ok(contaReceber);
    }

    [HttpPost("contas-receber/{idContaReceber}/parcelas")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Financeiro)}")]
    public async Task<IActionResult> CriarParcela(Guid idContaReceber, [FromBody] CriarParcelaCommand criarParcelaCommand)
    {
        Guid id = await this._mediator.Send(criarParcelaCommand with { ContaReceberId = idContaReceber });
        return Ok(id);
    }

    [HttpPut("parcelas/{id}/pagamento")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Financeiro)}")]
    public async Task<IActionResult> RegistrarPagamentoParcela(Guid id)
    {
        Guid parcelaId = await this._mediator.Send(new RegistrarPagamentoParcelaCommand(id));
        return Ok(parcelaId);
    }
}
