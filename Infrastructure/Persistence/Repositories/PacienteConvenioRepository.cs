using Domain.Entities.Convenios;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PacienteConvenioRepository : IPacienteConvenioRepository
{
    private readonly OdontoFlowDbContext _context;

    public PacienteConvenioRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<PacienteConvenio>> ObterPorPacienteIdAsync(Guid pacienteId)
    {
        return await this._context.PacientesConvenios
            .Where(pc => pc.PacienteId == pacienteId)
            .ToListAsync();
    }

    public async Task AddAsync(PacienteConvenio pacienteConvenio)
    {
        await this._context.PacientesConvenios.AddAsync(pacienteConvenio);
    }
}
