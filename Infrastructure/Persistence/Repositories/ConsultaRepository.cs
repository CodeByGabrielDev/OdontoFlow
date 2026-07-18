using Domain.Entities.Agenda;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;


public class ConsultaRepository : IConsultaRepository
{
    /*
    Task AddAsync(Consulta consulta);
    Task UpdateAsync(Consulta consulta);
    */
    private readonly OdontoFlowDbContext _odontoFlowDbContext;

    public ConsultaRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }


    public async Task<Consulta?> ObterPorIdAsync(Guid id)
    {
        return await this._odontoFlowDbContext.Consultas.Include(entidade => entidade.Paciente).Include(entidade => entidade.Dentista).FirstOrDefaultAsync(entidade => entidade.Id == id);
    }


    public async Task<bool> ExisteConflitoAsync(Guid dentistaId, DateTime data, TimeSpan horaInicio, TimeSpan horaFim)
    {
        return await this._odontoFlowDbContext.Consultas
    .Where(c => c.DentistaId == dentistaId
             && c.Data == data
             && c.HoraInicio < horaFim
             && c.HoraFim > horaInicio)
    .AnyAsync();
    }

    public async Task AddAsync(Consulta consulta)
    {
        await this._odontoFlowDbContext.Consultas.AddAsync(consulta);
    }

    public async Task UpdateAsync(Consulta consulta)
    {
        this._odontoFlowDbContext.Consultas.Update(consulta);
    }

}