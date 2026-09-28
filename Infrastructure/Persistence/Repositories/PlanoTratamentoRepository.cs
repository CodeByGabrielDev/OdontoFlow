using Domain.Entities.Prontuario;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class PlanoTratamentoRepository : IPlanoTratamentoRepository
{
    private readonly OdontoFlowDbContext _context;

    public PlanoTratamentoRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task AddAsync(PlanoTratamento planoTratamento)
    {
        await this._context.PlanosTratamento.AddAsync(planoTratamento);
    }
}
