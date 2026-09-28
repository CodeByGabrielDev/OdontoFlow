using Domain.Entities.Financeiro;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class OrcamentoRepository : IOrcamentoRepository
{
    private readonly OdontoFlowDbContext _context;

    public OrcamentoRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<Orcamento?> ObterPorIdAsync(Guid id)
    {
        return await this._context.Orcamentos.FindAsync(id);
    }

    public async Task AddAsync(Orcamento orcamento)
    {
        await this._context.Orcamentos.AddAsync(orcamento);
    }

    public Task UpdateAsync(Orcamento orcamento)
    {
        this._context.Orcamentos.Update(orcamento);
        return Task.CompletedTask;
    }
}
