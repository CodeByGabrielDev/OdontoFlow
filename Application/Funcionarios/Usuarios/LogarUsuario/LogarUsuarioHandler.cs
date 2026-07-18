using Domain.Entities.Funcionarios;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Funcionarios.Usuarios.LogarUsuario;


public class LogarUsuarioHandler : IRequestHandler<LogarUsuarioCommand, string>
{
    private readonly IJwtService _jwtService;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher _passwordHasher;
    public LogarUsuarioHandler(IJwtService _jwtService, IUsuarioRepository _usuarioRepository, IPasswordHasher _passwordHasher)
    {
        this._jwtService = _jwtService;
        this._usuarioRepository = _usuarioRepository;
        this._passwordHasher = _passwordHasher;
    }

    public async Task<string> Handle(LogarUsuarioCommand logarUsuarioCommand, CancellationToken cancellationToken)
    {
        Usuario? usuario = await this._usuarioRepository.ObterPorEmailAsync(logarUsuarioCommand.Email);
        if (usuario == null)
        {
            throw new DomainException("Usuario nao encontrado");
        }
        if (!this._passwordHasher.Verify(logarUsuarioCommand.Senha, usuario.SenhaHash))
        {
            throw new DomainException("Email ou senha incorretas");
        }
        return this._jwtService.GerarToken(usuario);
    }
}