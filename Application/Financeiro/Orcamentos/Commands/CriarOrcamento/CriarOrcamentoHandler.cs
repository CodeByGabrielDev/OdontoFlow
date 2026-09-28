using Domain.Entities.Financeiro;
using Domain.Entities.Funcionarios;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.Orcamentos.Commands.CriarOrcamento;

public class CriarOrcamentoHandler : IRequestHandler<CriarOrcamentoCommand, Guid>
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IDentistaRepository _dentistaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarOrcamentoHandler(IOrcamentoRepository orcamentoRepository, IPacienteRepository pacienteRepository, IDentistaRepository dentistaRepository, IUnitOfWork unitOfWork)
    {
        this._orcamentoRepository = orcamentoRepository;
        this._pacienteRepository = pacienteRepository;
        this._dentistaRepository = dentistaRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CriarOrcamentoCommand command, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(command.PacienteId);
        if (paciente == null) throw new DomainException("Paciente nao encontrado na base de dados.");
        Dentista? dentista = await this._dentistaRepository.ObterDentistaPorIdAsync(command.DentistaId);
        if (dentista == null) throw new DomainException("Dentista nao encontrado na base de dados.");

        Orcamento orcamento = new Orcamento(command.PacienteId, command.DentistaId, command.Descricao, command.ValorTotal);
        await this._orcamentoRepository.AddAsync(orcamento);
        await this._unitOfWork.SaveChangesAsync();
        return orcamento.Id;
    }
}
