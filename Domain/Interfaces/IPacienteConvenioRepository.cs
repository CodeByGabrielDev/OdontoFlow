using Domain.Entities.Convenios;

namespace Domain.Interfaces;

public interface IPacienteConvenioRepository
{
    Task<IEnumerable<PacienteConvenio>> ObterPorPacienteIdAsync(Guid pacienteId);
    Task AddAsync(PacienteConvenio pacienteConvenio);
}
