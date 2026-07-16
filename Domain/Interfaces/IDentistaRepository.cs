using Domain.Entities.Funcionarios;

namespace Domain.Interfaces;


public interface IDentistaRepository
{
    Task AddAsync(Dentista dentista);
    Task<Dentista> ObterDentistaPorIdAsync(Guid Id);
    Task<bool> ValidaExistenciaDeDentistaPorUfECro(string UfCro, string NumeroCro);
}