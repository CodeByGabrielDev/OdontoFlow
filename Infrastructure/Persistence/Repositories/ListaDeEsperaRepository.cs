using Domain.Entities.Agenda;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ListaDeEsperaRepository : IListaDeEsperaRepository
{
    private readonly OdontoFlowDbContext _odontoFlowDbContext;

    public ListaDeEsperaRepository(OdontoFlowDbContext _odontoFlowDbContext)
    {
        this._odontoFlowDbContext = _odontoFlowDbContext;
    }
    public async Task<ListaEspera> BuscarListaDePacientePorCpf(string cpf)
    {
        return await this._odontoFlowDbContext.ListasEspera
                         .Where(entidadeLista => entidadeLista.Paciente.Cpf.Valor == cpf)
                         .Include(entidadeLista => entidadeLista.Paciente)
                         .Include(entidadeLista => entidadeLista.Dentista).FirstAsync();
    }
    public async Task<ListaEspera?> BuscarListaDePacientePorId(Guid id)
    {
        return await this._odontoFlowDbContext.ListasEspera.FindAsync(id);
    }
    public async Task CriarListaDeEspera(ListaEspera listaEspera)
    {
        await this._odontoFlowDbContext.ListasEspera.AddAsync(listaEspera);
    }

    public async Task<List<ListaEspera>> BuscarListaDeEsperaDentistaNaoAtendidos(Guid IdDentista)
    {
        return await this._odontoFlowDbContext.ListasEspera
                                                   .Where(entidadeLista => entidadeLista.DentistaId == IdDentista && !entidadeLista.Atendido)
                                                   .Include(entidadeLista => entidadeLista.Dentista)
                                                   .Include(entidadeLista => entidadeLista.Paciente)
                                                   .ToListAsync();
    }

    public async Task UpdateAsync(ListaEspera lista)
    {
        this._odontoFlowDbContext.ListasEspera.Update(lista);
    }
}