using Domain.Entities.Financeiro;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.Orcamentos.Commands.AssinarOrcamento;

public class AssinarOrcamentoHandler : IRequestHandler<AssinarOrcamentoCommand, Guid>
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssinarOrcamentoHandler(IOrcamentoRepository orcamentoRepository, IUnitOfWork unitOfWork)
    {
        this._orcamentoRepository = orcamentoRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AssinarOrcamentoCommand command, CancellationToken cancellationToken)
    {
        Orcamento? orcamento = await this._orcamentoRepository.ObterPorIdAsync(command.OrcamentoId);
        if (orcamento == null) throw new DomainException("Orcamento nao encontrado na base de dados.");
        orcamento.Assinar();
        await this._orcamentoRepository.UpdateAsync(orcamento);
        await this._unitOfWork.SaveChangesAsync();
        return orcamento.Id;
    }
}
