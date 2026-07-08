using Domain.Entities.Estoque;

namespace Domain.Interfaces;

public interface IEstoqueRepository
{
    Task<ItemEstoque?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<ItemEstoque>> ObterAbaixoMinimoAsync();
    Task AddAsync(ItemEstoque item);
    Task UpdateAsync(ItemEstoque item);
}
