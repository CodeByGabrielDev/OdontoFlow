using Domain.Enums;
using MediatR;

namespace Application.Funcionarios.Funcionario.Commands.CriarFuncionario;

public record CriarFuncionarioCommand(string Nome, string Email, string Telefone, TipoPerfil Perfil) : IRequest<Guid>;
