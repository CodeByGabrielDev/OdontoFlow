using Domain.Entities.Prontuario;

namespace Domain.Interfaces;

public interface IPlanoTratamentoRepository
{
    Task AddAsync(PlanoTratamento planoTratamento);
}
