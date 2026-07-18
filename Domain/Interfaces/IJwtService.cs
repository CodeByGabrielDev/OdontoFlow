using Domain.Entities.Funcionarios;

namespace Domain.Interfaces;


public interface IJwtService
{
    string GerarToken(Usuario usuario);
}