using System.Runtime.InteropServices;
using Domain.Entities.Funcionarios;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Agenda.ListaEspera.Commands.CriarListaDeEspera;


public class CriarListaDeEsperaHandler : IRequestHandler<CriarListaDeEsperaCommand, Guid>
{
    private readonly IListaDeEsperaRepository _listaDeEsperaRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IDentistaRepository _dentistaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CriarListaDeEsperaHandler(IListaDeEsperaRepository _listaDeEsperaRepository, IPacienteRepository _pacienteRepository, IUnitOfWork _unitOfWork, IDentistaRepository _dentistaRepository)
    {
        this._listaDeEsperaRepository = _listaDeEsperaRepository;
        this._pacienteRepository = _pacienteRepository;
        this._dentistaRepository = _dentistaRepository;
        this._unitOfWork = _unitOfWork;
    }


    public async Task<Guid> Handle(CriarListaDeEsperaCommand criarListaDeEsperaCommand, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(criarListaDeEsperaCommand.PacienteId);
        if (paciente == null)
        {
            throw new DomainException("paciente nao encontrado na base de dados");
        }
        Dentista? dentista = await this._dentistaRepository.ObterDentistaPorIdAsync(criarListaDeEsperaCommand.DentistaId);
        if (dentista == null)
        {
            throw new DomainException("dentista nao encontrado na base de dados");
        }
        Domain.Entities.Agenda.ListaEspera lista = new Domain.Entities.Agenda.ListaEspera(paciente.Id, dentista.Id, criarListaDeEsperaCommand.Observacao);
        await this._listaDeEsperaRepository.CriarListaDeEspera(lista);
        await this._unitOfWork.SaveChangesAsync();
        return lista.Id;
    }
}