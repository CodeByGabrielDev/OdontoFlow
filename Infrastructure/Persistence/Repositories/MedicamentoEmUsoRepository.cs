using Domain.Entities.Pacientes;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class MedicamentoEmUsoRepository : IMedicamentoEmUsoRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;
    public MedicamentoEmUsoRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext=_odontoFlowDbContext;
    }
    public async Task AddAsync(MedicamentoEmUso medicamentoEmUso)
    {
        await this._odontoFlowDbContext.MedicamentoEmUso.AddAsync(medicamentoEmUso);
    }
}