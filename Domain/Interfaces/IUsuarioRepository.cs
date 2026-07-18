using Domain.Entities.Funcionarios;

namespace Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario> ObterPorEmailAsync(string Email);
    Task AddAsync(Usuario usuario);
}