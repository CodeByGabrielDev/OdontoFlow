using Domain.Entities.Agenda;

namespace Domain.Interfaces;


public interface IGradeHorarioRepository
{
    Task AddAsync(GradeHorario gradeHorario);
    Task<GradeHorario> BuscarGradePorId(Guid id);
    Task<List<GradeHorario>> BuscarGradePorDentistaId(Guid idDentista);
    Task<bool> VerificarConflitanciaNaAgenda(string diaSemana, Guid DentistaId);

    Task<bool> VerificarDisponibilidadeNaGrade(Guid IdDentista, string dayOfWeek, TimeSpan dataInicio, TimeSpan dataFim);
}