using Domain.Entities.Agenda;
using Domain.Entities.Funcionarios;
using Domain.Entities.Pacientes;
using Domain.Entities.Prontuario;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Prontuarios.Command.ProntuarioCommand;

public class EvolucaoClinicaHandler : IRequestHandler<EvolucaoClinicaCommand.EvolucaoClinicaCommand, Guid>
{

    private readonly IEvolucaoClinicaRepository _evolucaoClinicaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProntuarioRepository _prontuarioRepository;
    private readonly IDentistaRepository _dentistaRepository;
    private readonly IConsultaRepository _consultaRepository;
    public EvolucaoClinicaHandler(IConsultaRepository _consultaRepository,IDentistaRepository _dentistaRepository,IProntuarioRepository _prontuarioRepository,IEvolucaoClinicaRepository _evolucaoClinicaRepository,IUnitOfWork _unitOfWork)
    {
        this._evolucaoClinicaRepository = _evolucaoClinicaRepository;
        this._unitOfWork = _unitOfWork;
        this._prontuarioRepository = _prontuarioRepository;
        this._dentistaRepository = _dentistaRepository;
        this._consultaRepository = _consultaRepository;
    }


    public async Task<Guid> Handle(EvolucaoClinicaCommand.EvolucaoClinicaCommand evolucaoClinicaCommand, CancellationToken cancellationToken)
    {
        
        Dentista? dentista = await this._dentistaRepository.ObterDentistaPorIdAsync(evolucaoClinicaCommand.DentistaId);
        Prontuario? prontuario = await this._prontuarioRepository.ObterPorIdAsync(evolucaoClinicaCommand.ProntuarioId);
        Consulta? consulta = await this._consultaRepository.ObterPorIdAsync(evolucaoClinicaCommand.ConsultaId);
        if (dentista == null)
        {
            throw new DomainException("Dentista não encontrado na base de dados.");
        }
        if (prontuario == null)
        {
            throw new DomainException("Prontuario nao encontrado na base de dados");
        }
        if (consulta == null)
        {
            throw new DomainException("Consulta nao encontrada na base de dados");
        }

        EvolucaoClinica evolucaoClinica = new EvolucaoClinica(evolucaoClinicaCommand.ProntuarioId,evolucaoClinicaCommand.DentistaId,evolucaoClinicaCommand.ConsultaId,evolucaoClinicaCommand.Descricao ?? null);
        await this._evolucaoClinicaRepository.AddAsync(evolucaoClinica);
        await this._unitOfWork.SaveChangesAsync();
        return evolucaoClinica.Id;

    }
}