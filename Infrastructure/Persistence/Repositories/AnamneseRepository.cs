using Domain.Entities.Pacientes;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;


public class AnamneseRepository : IAnamneseRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;
    public AnamneseRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }
    public async Task<Anamnese?> BuscarAnamnesePorIdDoPaciente(Guid pacienteId)
    {
        Anamnese? anamnese = await this._odontoFlowDbContext.Anamneses.Include(entidade=>entidade.Paciente).Where(entidade => entidade.PacienteId == pacienteId)
                                                                      .FirstOrDefaultAsync();
        return anamnese;                                                               
    }
    public async Task AddAsync(Anamnese anamnese)
    {
        await this._odontoFlowDbContext.AddAsync(anamnese);
    }
}