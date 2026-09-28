using Domain.Entities.Financeiro;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class ParcelaRepository : IParcelaRepository
{
    private readonly OdontoFlowDbContext _context;

    public ParcelaRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<Parcela?> ObterPorIdAsync(Guid id)
    {
        return await this._context.Parcelas.FindAsync(id);
    }

    public async Task AddAsync(Parcela parcela)
    {
        await this._context.Parcelas.AddAsync(parcela);
    }

    public Task UpdateAsync(Parcela parcela)
    {
        this._context.Parcelas.Update(parcela);
        return Task.CompletedTask;
    }
}
