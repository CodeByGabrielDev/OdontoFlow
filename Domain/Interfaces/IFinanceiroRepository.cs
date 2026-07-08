using Domain.Entities.Financeiro;

namespace Domain.Interfaces;

public interface IFinanceiroRepository
{
    Task<ContaReceber?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<ContaReceber>> ObterPorPacienteIdAsync(Guid pacienteId);
    Task AddAsync(ContaReceber contaReceber);
    Task UpdateAsync(ContaReceber contaReceber);
}
