using Domain.Entities.Agenda;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Agenda.Consultas.Commands.CancelarConsulta;



public class CancelarConsultaHandler : IRequestHandler<CancelarConsultaCommand, Guid>
{

    private readonly IConsultaRepository _consultaRepository;
    private readonly IListaDeEsperaRepository _listaDeEsperaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelarConsultaHandler(IConsultaRepository _consultaRepository, IListaDeEsperaRepository _listaDeEsperaRepository, IUnitOfWork _unitOfWork)
    {
        this._consultaRepository = _consultaRepository;
        this._listaDeEsperaRepository = _listaDeEsperaRepository;
        this._unitOfWork = _unitOfWork;
    }

    public async Task<Guid> Handle(CancelarConsultaCommand cancelarConsultaCommand, CancellationToken cancellationToken)
    {
        Consulta? consulta = await this._consultaRepository.ObterPorIdAsync(cancelarConsultaCommand.Id);
        if (consulta == null)
        {
            throw new DomainException("Consulta nao encontrada na base de dados");
        }
        consulta.CancelarConsulta();
        List<ListaEspera> listaEspera = await this._listaDeEsperaRepository.BuscarListaDeEsperaDentistaNaoAtendidos(consulta.DentistaId);   
        int counter = 1;
        foreach (ListaEspera lista in listaEspera)
        {
            if (counter > 1)
            {
                break;
            }
            lista.AtualizarStatus();
            Consulta consultaNova = new Consulta(lista.PacienteId, lista.DentistaId, consulta.Data, consulta.HoraInicio, consulta.HoraFim, consulta.Observacao);
            await this._listaDeEsperaRepository.UpdateAsync(lista);
            await this._consultaRepository.AddAsync(consultaNova);
            counter++;
        }
        await this._consultaRepository.UpdateAsync(consulta);
        await this._unitOfWork.SaveChangesAsync();
        return consulta.Id;


    }

}