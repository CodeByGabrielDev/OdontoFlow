using Application.Pacientes.Queries.ObterPacientePorId;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Anamneses.Commands.CriarAnamnese;


public class CriarAnamneseHandler : IRequestHandler<CriarAnamneseCommand, Guid>
{

    private readonly IAnamneseRepository _anamneseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPacienteRepository _pacienteRepository;

    public CriarAnamneseHandler(IAnamneseRepository _anamneseRepository,IPacienteRepository _pacienteRepository, IUnitOfWork _unitOfWork)
    {
        this._anamneseRepository = _anamneseRepository;
        this._pacienteRepository = _pacienteRepository;
        this._unitOfWork = _unitOfWork;
    }

    public async Task<Guid> Handle(CriarAnamneseCommand criarAnamneseCommand, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(criarAnamneseCommand.PacienteId);
        if (paciente == null)
        {
            throw new DomainException("Paciente nao encontrado na base de dados, valide!");
        }
        Anamnese? anamnese = await this._anamneseRepository.BuscarAnamnesePorIdDoPaciente(criarAnamneseCommand.PacienteId);
        if (anamnese != null)
        {
            throw new DomainException("Ja existe uma anamnese criada para esse paciente");
        }
        /*public Anamnese(Guid pacienteId,string? alergias,string? medicamentoEmUso,string? doencasSistemicas)*/
        Anamnese anamneseEntity = new Anamnese(criarAnamneseCommand.PacienteId);
        anamneseEntity.insereCamposEValidaParametros(criarAnamneseCommand.Alergias, criarAnamneseCommand.MedicamentoEmUso, criarAnamneseCommand.DoencasSistemicas);

        await this._anamneseRepository.AddAsync(anamneseEntity);
        await this._unitOfWork.SaveChangesAsync();

        return anamneseEntity.Id;
    }
}