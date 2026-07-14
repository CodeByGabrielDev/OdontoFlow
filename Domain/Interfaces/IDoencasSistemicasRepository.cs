using Domain.Entities.Pacientes;

namespace Domain.Interfaces;

public interface IDoencasSistemicasRepository
{
    Task AddAsync(DoencasSistemicas doencasSistemicas);
}