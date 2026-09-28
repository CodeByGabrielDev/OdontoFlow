using Domain.Entities.Convenios;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class GuiaAutorizacaoRepository : IGuiaAutorizacaoRepository
{
    private readonly OdontoFlowDbContext _context;

    public GuiaAutorizacaoRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<GuiaAutorizacao?> ObterPorIdAsync(Guid id)
    {
        return await this._context.GuiasAutorizacao.FindAsync(id);
    }

    public async Task AddAsync(GuiaAutorizacao guiaAutorizacao)
    {
        await this._context.GuiasAutorizacao.AddAsync(guiaAutorizacao);
    }

    public Task UpdateAsync(GuiaAutorizacao guiaAutorizacao)
    {
        this._context.GuiasAutorizacao.Update(guiaAutorizacao);
        return Task.CompletedTask;
    }
}
