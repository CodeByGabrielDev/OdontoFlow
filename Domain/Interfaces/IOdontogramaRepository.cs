using Domain.Entities.Prontuario;

namespace Domain.Interfaces;

public interface IOdontogramaRepository
{
    Task AddAsync(Odontograma odontograma);
}