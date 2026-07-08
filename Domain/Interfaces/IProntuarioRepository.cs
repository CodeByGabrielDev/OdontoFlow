using Domain.Entities.Prontuario;

namespace Domain.Interfaces;

public interface IProntuarioRepository
{
    Task<Prontuario?> ObterPorIdAsync(Guid id);
    Task<Prontuario?> ObterPorPacienteIdAsync(Guid pacienteId);
    Task AddAsync(Prontuario prontuario);
}
