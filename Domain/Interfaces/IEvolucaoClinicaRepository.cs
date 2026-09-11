using Domain.Entities.Prontuario;

namespace Domain.Interfaces;



public interface IEvolucaoClinicaRepository
{
    Task AddAsync(EvolucaoClinica evolucaoClinica);
    
}