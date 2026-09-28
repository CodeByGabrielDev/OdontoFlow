using Domain.Entities.Prontuario;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProntuarioRepository : IProntuarioRepository
{
    private readonly OdontoFlowDbContext odontoFlowDbContext;

    public ProntuarioRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this.odontoFlowDbContext = _odontoFlowDbContext;
    }

    private IQueryable<Prontuario> ComNavegacoes()
    {
        return this.odontoFlowDbContext.Prontuarios
            .Include(p => p.Paciente)
            .Include(p => p.Odontograma).ThenInclude(o => o.Dentes).ThenInclude(d => d.StatusFaces)
            .Include(p => p.EvolucaoClinicas)
            .Include(p => p.PlanosTratamento)
            .Include(p => p.Prescricoes);
    }

    public async Task<Prontuario?> ObterPorIdAsync(Guid id)
    {
        return await this.ComNavegacoes().FirstOrDefaultAsync(entidadeProntuario => entidadeProntuario.Id == id);
    }
    public async Task<Prontuario?> ObterPorPacienteIdAsync(Guid idPaciente)
    {
        return await this.odontoFlowDbContext.Prontuarios
                                             .Where(entidadeProntuario=>entidadeProntuario.PacienteId == idPaciente)
                                             .FirstOrDefaultAsync();
    }
    public async Task AddAsync(Prontuario prontuario)
    {
        await this.odontoFlowDbContext.Prontuarios.AddAsync(prontuario);
    }
    public async Task<List<Prontuario?>> ObterProntuariosPorCpfPaciente(string cpf)
    {
        return await this.ComNavegacoes().Where(entidadeProntuario=>entidadeProntuario.Paciente.Cpf.Valor == cpf).ToListAsync<Prontuario?>();
    }


    public async Task<List<Prontuario?>> ObterTodos()
    {
        return await this.ComNavegacoes().ToListAsync<Prontuario?>();
    }


}
