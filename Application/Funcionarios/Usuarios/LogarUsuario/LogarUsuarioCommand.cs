using MediatR;

namespace Application.Funcionarios.Usuarios.LogarUsuario;


public record LogarUsuarioCommand(string Email, string Senha) : IRequest<string>;