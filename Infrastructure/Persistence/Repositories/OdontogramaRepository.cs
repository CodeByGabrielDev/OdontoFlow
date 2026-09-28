using Domain.Entities.Prontuario;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class OdontogramaRepository : IOdontogramaRepository
{

    private readonly OdontoFlowDbContext _context;

    public OdontogramaRepository(OdontoFlowDbContext _context)
    {
        this._context = _context;
    }

    public async Task AddAsync(Odontograma odontograma)
    {
        await this._context.Odontogramas.AddAsync(odontograma);
    }

    public async Task<Odontograma?> ObterPorProntuarioIdAsync(Guid prontuarioId)
    {
        return await this._context.Odontogramas
            .Include(o => o.Dentes).ThenInclude(d => d.StatusFaces)
            .FirstOrDefaultAsync(o => o.ProntuarioId == prontuarioId);
    }
}
