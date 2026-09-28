using Domain.Entities.Estoque;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class EstoqueRepository : IEstoqueRepository
{
    private readonly OdontoFlowDbContext _context;

    public EstoqueRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<ItemEstoque?> ObterPorIdAsync(Guid id)
    {
        return await this._context.ItensEstoque.FindAsync(id);
    }

    public async Task<IEnumerable<ItemEstoque>> ObterTodosAsync()
    {
        return await this._context.ItensEstoque.ToListAsync();
    }

    public async Task<IEnumerable<ItemEstoque>> ObterAbaixoMinimoAsync()
    {
        return await this._context.ItensEstoque
            .Where(item => item.QuantidadeAtual < item.QuantidadeMinima)
            .ToListAsync();
    }

    public async Task AddAsync(ItemEstoque item)
    {
        await this._context.ItensEstoque.AddAsync(item);
    }

    public Task UpdateAsync(ItemEstoque item)
    {
        this._context.ItensEstoque.Update(item);
        return Task.CompletedTask;
    }
}
