using Domain.Entities.Financeiro;

namespace Domain.Interfaces;

public interface IProcedimentoRepository
{
    Task<Procedimento?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Procedimento>> ObterTodosAsync();
    Task AddAsync(Procedimento procedimento);
}
