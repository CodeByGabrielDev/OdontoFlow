using Application.Funcionarios.Dentista.Commands;
using Application.Funcionarios.Dentista.DTOs;
using Application.Funcionarios.Dentista.Queries;
using Domain.Entities.Funcionarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/dentista")]
public class DentistaController : ControllerBase
{
    private readonly IMediator _mediatR;

    public DentistaController(IMediator _mediatR)
    {
        this._mediatR = _mediatR;
    }
    [HttpGet]
    public async Task<IActionResult> ObterDentistaPorId(Guid Id)
    {
        DentistaDto dentistaDto = await this._mediatR.Send(new BuscarDentistaPorIdQuery(Id));
        return Ok(dentistaDto);
    }
    [HttpPost]
    public async Task<IActionResult> CriarDentista([FromBody] CriarDentistaCommand criarDentistaCommand)
    {
        Guid Id = await this._mediatR.Send(criarDentistaCommand);
        return Ok(Id);
    }
}