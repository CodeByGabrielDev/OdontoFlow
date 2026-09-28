using Domain.Entities.Convenios;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Convenios.PacienteConvenios.Commands.VincularPacienteConvenio;

public class VincularPacienteConvenioHandler : IRequestHandler<VincularPacienteConvenioCommand, Guid>
{
    private readonly IPacienteConvenioRepository _pacienteConvenioRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VincularPacienteConvenioHandler(IPacienteConvenioRepository pacienteConvenioRepository, IPacienteRepository pacienteRepository, IConvenioRepository convenioRepository, IUnitOfWork unitOfWork)
    {
        this._pacienteConvenioRepository = pacienteConvenioRepository;
        this._pacienteRepository = pacienteRepository;
        this._convenioRepository = convenioRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(VincularPacienteConvenioCommand command, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(command.PacienteId);
        if (paciente == null) throw new DomainException("Paciente nao encontrado na base de dados.");
        Convenio? convenio = await this._convenioRepository.ObterPorIdAsync(command.ConvenioId);
        if (convenio == null) throw new DomainException("Convenio nao encontrado na base de dados.");

        PacienteConvenio pacienteConvenio = new PacienteConvenio(command.PacienteId, command.ConvenioId, command.NumeroCarteirinha, command.Validade);
        await this._pacienteConvenioRepository.AddAsync(pacienteConvenio);
        await this._unitOfWork.SaveChangesAsync();
        return pacienteConvenio.Id;
    }
}
