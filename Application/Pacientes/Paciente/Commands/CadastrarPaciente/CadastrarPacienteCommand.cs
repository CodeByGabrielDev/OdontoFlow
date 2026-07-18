using MediatR;
namespace Application.Pacientes.Commands.CadastrarPaciente;

public record CadastrarPacienteCommand(string Nome,string Cpf,string Email,
string Telefone,DateTime DataNascimento,
string Sexo, string Endereco):IRequest<Guid>;