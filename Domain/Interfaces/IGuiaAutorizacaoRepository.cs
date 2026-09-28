using Domain.Entities.Convenios;

namespace Domain.Interfaces;

public interface IGuiaAutorizacaoRepository
{
    Task<GuiaAutorizacao?> ObterPorIdAsync(Guid id);
    Task AddAsync(GuiaAutorizacao guiaAutorizacao);
    Task UpdateAsync(GuiaAutorizacao guiaAutorizacao);
}
