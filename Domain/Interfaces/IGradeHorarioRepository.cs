using Domain.Entities.Agenda;

namespace Domain.Interfaces;


public interface IGradeHorarioRepository
{
    Task AddAsync(GradeHorario gradeHorario);
    Task<GradeHorario> BuscarGradePorId(Guid id);
    Task<List<GradeHorario>> BuscarGradePorDentistaId(Guid idDentista);
    Task<bool> VerificarConflitanciaNaAgenda(DayOfWeek diaSemana, Guid DentistaId);
}