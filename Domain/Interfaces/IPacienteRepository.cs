using Domain.Entities.Pacientes;
namespace Domain.Interfaces;
public interface IPacienteRepository
{
    Task<Paciente?> ObterPorIdAsync(Guid id);
    Task<bool> CpfJaCadastradoAsync(string cpf);
    Task AddAsync(Paciente paciente);
    Task UpdateAsync(Paciente paciente);
    
}