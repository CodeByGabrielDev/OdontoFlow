using Domain.Entities.Convenios;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ConvenioRepository : IConvenioRepository
{
    private readonly OdontoFlowDbContext _context;

    public ConvenioRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<Convenio?> ObterPorIdAsync(Guid id)
    {
        return await this._context.Convenios.FindAsync(id);
    }

    public async Task<IEnumerable<Convenio>> ObterTodosAsync()
    {
        return await this._context.Convenios.ToListAsync();
    }

    public async Task AddAsync(Convenio convenio)
    {
        await this._context.Convenios.AddAsync(convenio);
    }

    public Task UpdateAsync(Convenio convenio)
    {
        this._context.Convenios.Update(convenio);
        return Task.CompletedTask;
    }
}
