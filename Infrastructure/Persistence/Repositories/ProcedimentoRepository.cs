using Domain.Entities.Financeiro;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProcedimentoRepository : IProcedimentoRepository
{
    private readonly OdontoFlowDbContext _context;

    public ProcedimentoRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<Procedimento?> ObterPorIdAsync(Guid id)
    {
        return await this._context.Procedimentos.FindAsync(id);
    }

    public async Task<IEnumerable<Procedimento>> ObterTodosAsync()
    {
        return await this._context.Procedimentos.ToListAsync();
    }

    public async Task AddAsync(Procedimento procedimento)
    {
        await this._context.Procedimentos.AddAsync(procedimento);
    }
}
