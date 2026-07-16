using Domain.Entities.Agenda;

namespace Domain.Interfaces;

public interface IListaDeEsperaRepository
{
    Task<ListaEspera> BuscarListaDePacientePorCpf(string Cpf);
    Task<ListaEspera> BuscarListaDePacientePorId(Guid Id);
    Task CriarListaDeEspera(ListaEspera listaEspera);
    Task<List<ListaEspera>> BuscarListaDeEsperaDentistaNaoAtendidos(Guid IdDentista);
    Task UpdateAsync(ListaEspera listaEspera);
}