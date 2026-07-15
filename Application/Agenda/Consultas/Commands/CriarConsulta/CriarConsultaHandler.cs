using Application.Consultas.CriarConsulta;
using Domain.Entities.Agenda;
using Domain.Entities.Funcionarios;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Agenda.Consultas.CriarConsulta;


public class CriarConsultaHandler : IRequestHandler<CriarConsultaCommand, Guid>
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDentistaRepository _dentistaRepository;

    public CriarConsultaHandler(IConsultaRepository _consultaRepository, IPacienteRepository _pacienteRepository, IUnitOfWork _unitOfWork, IDentistaRepository _dentistaRepository)
    {
        this._consultaRepository = _consultaRepository;
        this._pacienteRepository = _pacienteRepository;
        this._unitOfWork = _unitOfWork;
        this._dentistaRepository = _dentistaRepository;
    }

    public async Task<Guid> Handle(CriarConsultaCommand criarConsultaCommand, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(criarConsultaCommand.PacienteId);
        if (paciente == null)
        {
            throw new DomainException("Paciente nao encontrado na base de dados");
        }
        Dentista? dentista = await this._dentistaRepository.ObterDentistaPorIdAsync(criarConsultaCommand.DentistaId);
        if (dentista == null)
        {
            throw new DomainException("Dentista nao encontrado na base de dados");
        }
        if (!dentista.Ativo || !paciente.Ativo)
        {
            throw new DomainException("Dentista ou Paciente não ativo no sistema!");
        }
        bool temConflito = await this._consultaRepository
                                     .ExisteConflitoAsync(criarConsultaCommand.DentistaId, criarConsultaCommand.Data,
                                      criarConsultaCommand.HoraInicio, criarConsultaCommand.HoraFim);
        if (criarConsultaCommand.Data <= DateTime.UtcNow)
        {
            throw new DomainException("Impossivel marcar para uma data anterior ao dia atual.");
        }
        if (temConflito)
        {
            throw new DomainException("Horario indisponivel para esse dentista, validar outro horario para o mesmo dentista");
        }

        Consulta consulta = new Consulta(paciente.Id, dentista.Id, criarConsultaCommand.Data, criarConsultaCommand.HoraInicio,
                                         criarConsultaCommand.HoraFim, criarConsultaCommand.Observacao);
        await this._consultaRepository.AddAsync(consulta);
        await this._unitOfWork.SaveChangesAsync();
        return consulta.Id; 
    }
}