using Domain.Entities.Funcionarios;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly OdontoFlowDbContext _context;

    public FuncionarioRepository(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<Funcionario?> ObterPorIdAsync(Guid id)
    {
        return await this._context.Funcionarios.FindAsync(id);
    }

    public async Task<IEnumerable<Funcionario>> ObterTodosAsync()
    {
        return await this._context.Funcionarios.ToListAsync();
    }

    public async Task AddAsync(Funcionario funcionario)
    {
        await this._context.Funcionarios.AddAsync(funcionario);
    }

    public Task UpdateAsync(Funcionario funcionario)
    {
        this._context.Funcionarios.Update(funcionario);
        return Task.CompletedTask;
    }
}
