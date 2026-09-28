using Domain.Entities.Convenios;
using Domain.Entities.Financeiro;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Convenios.GuiasAutorizacao.Commands.SolicitarGuia;

public class SolicitarGuiaHandler : IRequestHandler<SolicitarGuiaCommand, Guid>
{
    private readonly IGuiaAutorizacaoRepository _guiaAutorizacaoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IProcedimentoRepository _procedimentoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SolicitarGuiaHandler(IGuiaAutorizacaoRepository guiaAutorizacaoRepository, IPacienteRepository pacienteRepository, IConvenioRepository convenioRepository, IProcedimentoRepository procedimentoRepository, IUnitOfWork unitOfWork)
    {
        this._guiaAutorizacaoRepository = guiaAutorizacaoRepository;
        this._pacienteRepository = pacienteRepository;
        this._convenioRepository = convenioRepository;
        this._procedimentoRepository = procedimentoRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(SolicitarGuiaCommand command, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(command.PacienteId);
        if (paciente == null) throw new DomainException("Paciente nao encontrado na base de dados.");
        Convenio? convenio = await this._convenioRepository.ObterPorIdAsync(command.ConvenioId);
        if (convenio == null) throw new DomainException("Convenio nao encontrado na base de dados.");
        Procedimento? procedimento = await this._procedimentoRepository.ObterPorIdAsync(command.ProcedimentoId);
        if (procedimento == null) throw new DomainException("Procedimento nao encontrado na base de dados.");

        GuiaAutorizacao guia = new GuiaAutorizacao(command.PacienteId, command.ConvenioId, command.ProcedimentoId, command.Observacao);
        await this._guiaAutorizacaoRepository.AddAsync(guia);
        await this._unitOfWork.SaveChangesAsync();
        return guia.Id;
    }
}
