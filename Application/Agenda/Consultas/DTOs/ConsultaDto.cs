namespace Application.Consultas.DTOs;


public record ConsultaDto(string NomePaciente,string NomeDentista, DateTime Data, TimeSpan HoraInicio,
                          TimeSpan HoraFim,string StatusConsulta,string? Observacao, DateTime CriadoEm);