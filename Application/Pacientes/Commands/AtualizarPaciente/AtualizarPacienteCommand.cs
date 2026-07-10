using MediatR;

namespace Application.Pacientes.Commands.AtualizarPaciente;

public record AtualizarPacienteCommand(Guid Id,string? Nome,string? Email,
string? Telefone,DateTime DataNascimento,
string? Sexo, string? Endereco):IRequest<Unit>;

