using Domain.Entities.Prontuario;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;


public class EvolucaoClinicaRepository : IEvolucaoClinicaRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;

    public EvolucaoClinicaRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }
    public async Task AddAsync(EvolucaoClinica evolucaoClinica)
    {
        await this._odontoFlowDbContext.EvolucoesClinicas.AddAsync(evolucaoClinica);
    }
}