namespace Application.Agenda.GradeHorario.DTOs;


public record GradeHorarioDto(
    Guid Id,
    string DiaSemana,
    TimeSpan HoraInicio,
    TimeSpan HoraFim,
    bool Ativo
);