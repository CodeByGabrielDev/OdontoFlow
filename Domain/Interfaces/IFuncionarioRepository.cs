using Domain.Entities.Funcionarios;

namespace Domain.Interfaces;

public interface IFuncionarioRepository
{
    Task<Funcionario?> ObterPorIdAsync(Guid id);
    Task AddAsync(Funcionario funcionario);
    Task UpdateAsync(Funcionario funcionario);
}
