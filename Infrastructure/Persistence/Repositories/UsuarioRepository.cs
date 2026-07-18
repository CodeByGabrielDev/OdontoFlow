using Domain.Entities.Funcionarios;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;


public class UsuarioRepository : IUsuarioRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;


    public UsuarioRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }


    public async Task<Usuario> ObterPorEmailAsync(string email)
    {
        return await this._odontoFlowDbContext.Usuarios.Where(entidadeUsuario => entidadeUsuario.Email.Valor == email).FirstOrDefaultAsync();
    }
    public async Task AddAsync(Usuario usuario)
    {
        await this._odontoFlowDbContext.Usuarios.AddAsync(usuario);
    }
}