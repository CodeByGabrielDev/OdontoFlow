using Domain.Entities.Pacientes;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;


public class AlergiaRepository : IAlergiaRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;
    public AlergiaRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }
    public async Task AddAsync(Alergias alergias)
    {
        await this._odontoFlowDbContext.Alergias.AddAsync(alergias);
    }
}