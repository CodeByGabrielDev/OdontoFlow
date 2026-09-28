using Domain.Entities.Prontuario;

namespace Domain.Interfaces;

public interface IOdontogramaRepository
{
    Task AddAsync(Odontograma odontograma);
    Task<Odontograma?> ObterPorProntuarioIdAsync(Guid prontuarioId);
}
