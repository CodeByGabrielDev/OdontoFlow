namespace Application.Pacientes.DTOs;

public record PacienteResumoDto(Guid Id, string Nome, string Cpf, string Email, bool Ativo);
