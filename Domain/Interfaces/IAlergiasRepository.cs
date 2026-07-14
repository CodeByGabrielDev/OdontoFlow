using Domain.Entities.Pacientes;

namespace Domain.Interfaces;

public interface IAlergiaRepository
{
    Task AddAsync(Alergias alergias);
}