using Domain.Entities.Pacientes;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;


public class DoencasSistemicasRepository : IDoencasSistemicasRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;
    public DoencasSistemicasRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }
    public async Task AddAsync(DoencasSistemicas doencasSistemicas)
    {
        await this._odontoFlowDbContext.DoencasSistemicas.AddAsync(doencasSistemicas);
    }
}