using Domain.Entities.Prontuario;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

public class ProntuarioRepository : IProntuarioRepository
{
    private readonly OdontoFlowDbContext odontoFlowDbContext;

    public ProntuarioRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this.odontoFlowDbContext = _odontoFlowDbContext;
    }
    public async Task<Prontuario?> ObterPorIdAsync(Guid id)
    {
        return await this.odontoFlowDbContext.Prontuarios.FindAsync(id);
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
        return await this.odontoFlowDbContext.Prontuarios.Where(entidadeProntuario=>entidadeProntuario.Paciente.Cpf.Valor == cpf).ToListAsync();
    }


}