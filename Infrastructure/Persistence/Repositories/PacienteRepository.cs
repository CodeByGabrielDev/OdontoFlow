using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;


public class PacienteRepository : IPacienteRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;
    public PacienteRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }
    public async Task<Paciente?> ObterPorIdAsync(Guid id)
    {
        return await this._odontoFlowDbContext.Pacientes.FindAsync(id);
    }
    public async Task<bool> CpfJaCadastradoAsync(string cpf)
    {
        return await this._odontoFlowDbContext.Pacientes.AnyAsync(entidade => entidade.Cpf.Valor.Equals(cpf));
    }
    public async Task AddAsync(Paciente paciente)
    {
        await this._odontoFlowDbContext.AddAsync(paciente);
    }
    public Task Update(Paciente paciente)
    {
         this._odontoFlowDbContext.Pacientes.Update(paciente);
         return Task.CompletedTask;
    }
    public async Task<IEnumerable<Paciente>> ListarPacientesFiltradosAsync(string? cpf, string? nome)
    {
        var query = this._odontoFlowDbContext.Pacientes.AsQueryable();
        if (!string.IsNullOrWhiteSpace(cpf))
        {
          query = query.Where(entidade =>entidade.Cpf.Valor.Equals(cpf));  
        }
        if (!string.IsNullOrWhiteSpace(nome))
        {
            query = query.Where(entidade =>entidade.Nome.Contains(nome));
        }
        return await query.ToListAsync();
    }
}