using Domain.Entities.Pacientes;

namespace Domain.Interfaces;


public interface IMedicamentoEmUsoRepository
{
    Task AddAsync(MedicamentoEmUso medicamentoEmUso);
}