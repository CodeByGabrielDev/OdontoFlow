using MediatR;

namespace Application.Funcionarios.Dentista.Commands;


public record CriarDentistaCommand(string Nome, string NumeroCro, string UfCro, string Email,
                                   string Telefone, string Especialidade) : IRequest<Guid>;