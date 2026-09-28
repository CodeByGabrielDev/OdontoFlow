using Domain.Entities.Estoque;

namespace Domain.Interfaces;

public interface IMovimentacaoEstoqueRepository
{
    Task<IEnumerable<MovimentacaoEstoque>> ObterPorItemIdAsync(Guid itemEstoqueId);
    Task AddAsync(MovimentacaoEstoque movimentacaoEstoque);
}
