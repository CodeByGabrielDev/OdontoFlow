using Application.Funcionarios.Usuarios.CriarUsuario;
using Application.Funcionarios.Usuarios.LogarUsuario;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediatR;

    public UsuarioController(IMediator _mediatR)
    {
        this._mediatR = _mediatR;
    }
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegistrarUsuario([FromBody] CriarUsuarioCommand criarUsuarioCommand)
    {
        Guid Id = await this._mediatR.Send(criarUsuarioCommand);
        return Ok(Id);
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginUsuario([FromBody] LogarUsuarioCommand logarUsuarioCommand)
    {
        string tokenUser = await this._mediatR.Send(logarUsuarioCommand);
        return Ok(tokenUser);
    }
}