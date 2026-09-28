using Domain.Entities.Financeiro;

namespace Domain.Interfaces;

public interface IOrcamentoRepository
{
    Task<Orcamento?> ObterPorIdAsync(Guid id);
    Task AddAsync(Orcamento orcamento);
    Task UpdateAsync(Orcamento orcamento);
}
