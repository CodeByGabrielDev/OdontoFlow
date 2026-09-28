using Domain.Entities.Financeiro;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.ContasReceber.Commands.CriarContaReceber;

public class CriarContaReceberHandler : IRequestHandler<CriarContaReceberCommand, Guid>
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IFinanceiroRepository _financeiroRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarContaReceberHandler(IOrcamentoRepository orcamentoRepository, IFinanceiroRepository financeiroRepository, IUnitOfWork unitOfWork)
    {
        this._orcamentoRepository = orcamentoRepository;
        this._financeiroRepository = financeiroRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CriarContaReceberCommand command, CancellationToken cancellationToken)
    {
        Orcamento? orcamento = await this._orcamentoRepository.ObterPorIdAsync(command.OrcamentoId);
        if (orcamento == null) throw new DomainException("Orcamento nao encontrado na base de dados.");
        if (!orcamento.Assinado) throw new DomainException("Conta a receber so pode ser criada a partir de um orcamento assinado.");

        ContaReceber contaReceber = new ContaReceber(orcamento.PacienteId, orcamento.Id, orcamento.ValorTotal);
        await this._financeiroRepository.AddAsync(contaReceber);
        await this._unitOfWork.SaveChangesAsync();
        return contaReceber.Id;
    }
}
