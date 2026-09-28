using Domain.Entities.Convenios;

namespace Domain.Interfaces;

public interface IConvenioRepository
{
    Task<Convenio?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Convenio>> ObterTodosAsync();
    Task AddAsync(Convenio convenio);
    Task UpdateAsync(Convenio convenio);
}
