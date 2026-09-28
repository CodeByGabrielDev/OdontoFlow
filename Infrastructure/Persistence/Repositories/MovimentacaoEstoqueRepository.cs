using Domain.Entities.Estoque;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class MovimentacaoEstoqueRepository : IMovimentacaoEstoqueRepository
{
    private readonly OdontoFlowDbContext _context;

    public MovimentacaoEstoqueRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<MovimentacaoEstoque>> ObterPorItemIdAsync(Guid itemEstoqueId)
    {
        return await this._context.MovimentacoesEstoque
            .Where(movimentacao => movimentacao.ItemEstoqueId == itemEstoqueId)
            .ToListAsync();
    }

    public async Task AddAsync(MovimentacaoEstoque movimentacaoEstoque)
    {
        await this._context.MovimentacoesEstoque.AddAsync(movimentacaoEstoque);
    }
}
