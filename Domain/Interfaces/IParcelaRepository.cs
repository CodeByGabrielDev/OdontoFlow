using Domain.Entities.Financeiro;

namespace Domain.Interfaces;

public interface IParcelaRepository
{
    Task<Parcela?> ObterPorIdAsync(Guid id);
    Task AddAsync(Parcela parcela);
    Task UpdateAsync(Parcela parcela);
}
