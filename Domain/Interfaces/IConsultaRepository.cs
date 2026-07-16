using Domain.Entities.Agenda;

namespace Domain.Interfaces;


public interface IConsultaRepository
{
    Task<Consulta?> ObterPorIdAsync(Guid id);
    Task<bool>ExisteConflitoAsync(Guid dentistaId,DateTime data,TimeSpan horaInicio,TimeSpan horaFim);
    Task AddAsync(Consulta consulta);
    Task UpdateAsync(Consulta consulta);

    

}