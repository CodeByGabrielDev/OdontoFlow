using Domain.Entities.Prontuario;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class PrescricaoRepository : IPrescricaoRepository
{
    private readonly OdontoFlowDbContext _context;

    public PrescricaoRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task AddAsync(Prescricao prescricao)
    {
        await this._context.Prescricoes.AddAsync(prescricao);
    }
}
