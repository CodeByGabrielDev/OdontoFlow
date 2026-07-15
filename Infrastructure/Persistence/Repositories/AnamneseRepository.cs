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
        Anamnese? anamnese = await this._odontoFlowDbContext.Anamneses.Include(entidade=>entidade.Paciente)
                                                                      .Include(entidade=>entidade.Alergias)
                                                                      .Include(entidade=>entidade.MedicamentoEmUso)
                                                                      .Include(entidade=>entidade.DoencasSistemicas)
                                                                      .Where(entidade => entidade.PacienteId == pacienteId)
                                                                      .FirstOrDefaultAsync();
        return anamnese;                                                               
    }
    public async Task AddAsync(Anamnese anamnese)
    {
        await this._odontoFlowDbContext.AddAsync(anamnese);
    }
}