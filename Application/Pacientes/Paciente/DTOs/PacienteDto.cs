namespace Application.Pacientes.DTOs;

public record PacienteDto(Guid Id, string Nome, string Cpf, string Email,
string Telefone, DateTime DataNascimento, string Sexo,
string Endereco, bool Ativo, DateTime CriadoEm);
