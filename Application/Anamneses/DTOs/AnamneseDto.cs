namespace Application.Anamneses.DTOs;

public record AnamneseDto(string NomePaciente,string? Alergias, string? MedicamentosEmUso,string? DoencasSistemicas);