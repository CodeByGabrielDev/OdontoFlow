using Domain.Entities.Funcionarios;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class DentistaRepository : IDentistaRepository
{

    private readonly OdontoFlowDbContext _odontoFlowDbContext;

    public DentistaRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;

    }
    public async Task AddAsync(Dentista dentista)
    {
        await this._odontoFlowDbContext.Dentistas.AddAsync(dentista);
    }

    public async Task<Dentista?> ObterDentistaPorIdAsync(Guid id)
    {
        return await this._odontoFlowDbContext.Dentistas
                         .Where(entidadeDentista => entidadeDentista.Id == id)
                         .Include(entidadeDentista => entidadeDentista.Consultas)
                            .ThenInclude(entidadeConsulta => entidadeConsulta.Paciente)
                        .FirstOrDefaultAsync();
    }

    public async Task<bool> ValidaExistenciaDeDentistaPorUfECro(string UfCro, string NumeroCro)
    {
        return await this._odontoFlowDbContext.Dentistas.Where(entidadeDentista => entidadeDentista.Cro.Uf == UfCro && entidadeDentista.Cro.Numero == NumeroCro).AnyAsync();
    }
}