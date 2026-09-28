using Domain.Entities.Prontuario;

namespace Domain.Interfaces;

public interface IPrescricaoRepository
{
    Task AddAsync(Prescricao prescricao);
}
