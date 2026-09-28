using Domain.Entities.Financeiro;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class FinanceiroRepository : IFinanceiroRepository
{
    private readonly OdontoFlowDbContext _context;

    public FinanceiroRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<ContaReceber?> ObterPorIdAsync(Guid id)
    {
        return await this._context.ContasReceber
            .Include(c => c.Parcelas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<ContaReceber>> ObterPorPacienteIdAsync(Guid pacienteId)
    {
        return await this._context.ContasReceber
            .Include(c => c.Parcelas)
            .Where(c => c.PacienteId == pacienteId)
            .ToListAsync();
    }

    public async Task AddAsync(ContaReceber contaReceber)
    {
        await this._context.ContasReceber.AddAsync(contaReceber);
    }

    public Task UpdateAsync(ContaReceber contaReceber)
    {
        this._context.ContasReceber.Update(contaReceber);
        return Task.CompletedTask;
    }
}
