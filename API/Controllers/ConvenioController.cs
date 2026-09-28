using Application.Convenios.Convenios.Commands.AtivarDesativarConvenio;
using Application.Convenios.Convenios.Commands.CriarConvenio;
using Application.Convenios.Convenios.Queries.ListarConvenios;
using Application.Convenios.DTOs;
using Application.Convenios.GuiasAutorizacao.Commands.AutorizarGuia;
using Application.Convenios.GuiasAutorizacao.Commands.NegarGuia;
using Application.Convenios.GuiasAutorizacao.Commands.SolicitarGuia;
using Application.Convenios.GuiasAutorizacao.Queries.ObterGuiaPorId;
using Application.Convenios.PacienteConvenios.Commands.VincularPacienteConvenio;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/convenios")]
public class ConvenioController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConvenioController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListarConvenios()
    {
        List<ConvenioDto> convenios = await this._mediator.Send(new ListarConveniosQuery());
        return Ok(convenios);
    }

    [HttpPost]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)}")]
    public async Task<IActionResult> CriarConvenio([FromBody] CriarConvenioCommand criarConvenioCommand)
    {
        Guid id = await this._mediator.Send(criarConvenioCommand);
        return Ok(id);
    }

    [HttpPut("{id}/ativar")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)}")]
    public async Task<IActionResult> AtivarConvenio(Guid id)
    {
        Guid convenioId = await this._mediator.Send(new AtivarConvenioCommand(id));
        return Ok(convenioId);
    }

    [HttpPut("{id}/desativar")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)}")]
    public async Task<IActionResult> DesativarConvenio(Guid id)
    {
        Guid convenioId = await this._mediator.Send(new DesativarConvenioCommand(id));
        return Ok(convenioId);
    }

    [HttpPost("pacientes-convenios")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)}")]
    public async Task<IActionResult> VincularPacienteConvenio([FromBody] VincularPacienteConvenioCommand vincularPacienteConvenioCommand)
    {
        Guid id = await this._mediator.Send(vincularPacienteConvenioCommand);
        return Ok(id);
    }

    [HttpPost("guias")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)},{nameof(TipoPerfil.Dentista)}")]
    public async Task<IActionResult> SolicitarGuia([FromBody] SolicitarGuiaCommand solicitarGuiaCommand)
    {
        Guid id = await this._mediator.Send(solicitarGuiaCommand);
        return Ok(id);
    }

    [HttpGet("guias/{id}")]
    public async Task<IActionResult> ObterGuiaPorId(Guid id)
    {
        GuiaAutorizacaoDto guia = await this._mediator.Send(new ObterGuiaPorIdQuery(id));
        return Ok(guia);
    }

    [HttpPut("guias/{id}/autorizar")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)}")]
    public async Task<IActionResult> AutorizarGuia(Guid id)
    {
        Guid guiaId = await this._mediator.Send(new AutorizarGuiaCommand(id));
        return Ok(guiaId);
    }

    [HttpPut("guias/{id}/negar")]
    [Authorize(Roles = $"{nameof(TipoPerfil.Admin)},{nameof(TipoPerfil.Secretaria)}")]
    public async Task<IActionResult> NegarGuia(Guid id)
    {
        Guid guiaId = await this._mediator.Send(new NegarGuiaCommand(id));
        return Ok(guiaId);
    }
}
