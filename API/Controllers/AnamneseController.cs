using Application.Anamneses.DTOs;
using Application.Anamneses.Queries.BuscarAnamnesePorPaciente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/anamnese")]
public class AnamneseController:ControllerBase
{
    private readonly IMediator _mediatR;

    public AnamneseController(IMediator _mediatR)
    {
     this._mediatR = _mediatR;   
    }
    [HttpGet("{idPaciente}")]
    public async Task<IActionResult> ObterAnamnesePorIdDoPaciente(Guid idPaciente)
    {
        AnamneseDto anamneseDto = await this._mediatR.Send(new BuscarAnamneseQuery(idPaciente));
        return Ok(anamneseDto);
    }
    

    

}