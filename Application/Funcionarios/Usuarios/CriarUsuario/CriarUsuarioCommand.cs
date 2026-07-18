using MediatR;

namespace Application.Funcionarios.Usuarios.CriarUsuario;

public record CriarUsuarioCommand(string Nome, string Email, string Perfil, string Senha) : IRequest<Guid>;