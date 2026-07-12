using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly OdontoFlowDbContext _context;

    public UnitOfWork(OdontoFlowDbContext context)
    {
        this._context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await this._context.SaveChangesAsync();
    }
}