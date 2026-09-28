using Application.Prontuarios.Command.EvolucaoClinicaCommand;
using Application.Prontuarios.Command.PlanoTratamentoCommand;
using Application.Prontuarios.Command.PrescricaoCommand;
using Application.Prontuarios.Command.ProntuarioCommand;
using Application.Prontuarios.DTOs;
using Application.Prontuarios.Queries.ListarProntuarios;
using Application.Prontuarios.Queries.ObterProntuarioPorId;
using Domain.Enums;
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

    [HttpGet]
    public async Task<IActionResult> ListarProntuarios()
    {
        List<ProntuarioDto> prontuarios = await this._mediator.Send(new ListarTodosProntuariosQuery());
        return Ok(prontuarios);
    }

    [HttpGet("{idProntuario}")]
    public async Task<IActionResult> ObterProntuarioPorId(Guid idProntuario)
    {
        ProntuarioDto prontuarioDto = await this._mediator.Send(new ObterProntuarioPorIdQuery(idProntuario));
        return Ok(prontuarioDto);
    }

    [HttpPost]
    public async Task<IActionResult> CriarProntuario([FromBody]CriarProntuarioCommand criarProntuarioCommand)
    {
        ProntuarioDto prontuarioDto = await this._mediator.Send(criarProntuarioCommand);
        return Ok(prontuarioDto);
    }

    [HttpPost("{idProntuario}/evolucoes")]
    [Authorize(Roles = nameof(TipoPerfil.Dentista))]
    public async Task<IActionResult> AdicionarEvolucaoClinica(Guid idProntuario, [FromBody] EvolucaoClinicaCommand evolucaoClinicaCommand)
    {
        Guid id = await this._mediator.Send(evolucaoClinicaCommand with { ProntuarioId = idProntuario });
        return Ok(id);
    }

    [HttpPost("{idProntuario}/planos-tratamento")]
    [Authorize(Roles = nameof(TipoPerfil.Dentista))]
    public async Task<IActionResult> AdicionarPlanoTratamento(Guid idProntuario, [FromBody] PlanoTratamentoCommand planoTratamentoCommand)
    {
        Guid id = await this._mediator.Send(planoTratamentoCommand with { ProntuarioId = idProntuario });
        return Ok(id);
    }

    [HttpPost("{idProntuario}/prescricoes")]
    [Authorize(Roles = nameof(TipoPerfil.Dentista))]
    public async Task<IActionResult> AdicionarPrescricao(Guid idProntuario, [FromBody] PrescricaoCommand prescricaoCommand)
    {
        Guid id = await this._mediator.Send(prescricaoCommand with { ProntuarioId = idProntuario });
        return Ok(id);
    }
}
