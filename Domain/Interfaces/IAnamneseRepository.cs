using Domain.Entities.Pacientes;

namespace Domain.Interfaces;


public interface IAnamneseRepository
{
    Task<Anamnese?> BuscarAnamnesePorIdDoPaciente(Guid PacienteId);
    Task AddAsync(Anamnese anamnese);
}