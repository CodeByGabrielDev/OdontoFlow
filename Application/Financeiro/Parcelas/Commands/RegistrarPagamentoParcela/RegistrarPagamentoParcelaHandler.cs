using Domain.Entities.Financeiro;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.Parcelas.Commands.RegistrarPagamentoParcela;

public class RegistrarPagamentoParcelaHandler : IRequestHandler<RegistrarPagamentoParcelaCommand, Guid>
{
    private readonly IParcelaRepository _parcelaRepository;
    private readonly IFinanceiroRepository _financeiroRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegistrarPagamentoParcelaHandler(IParcelaRepository parcelaRepository, IFinanceiroRepository financeiroRepository, IUnitOfWork unitOfWork)
    {
        this._parcelaRepository = parcelaRepository;
        this._financeiroRepository = financeiroRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RegistrarPagamentoParcelaCommand command, CancellationToken cancellationToken)
    {
        Parcela? parcela = await this._parcelaRepository.ObterPorIdAsync(command.ParcelaId);
        if (parcela == null) throw new DomainException("Parcela nao encontrada na base de dados.");
        ContaReceber? contaReceber = await this._financeiroRepository.ObterPorIdAsync(parcela.ContaReceberId);
        if (contaReceber == null) throw new DomainException("Conta a receber nao encontrada na base de dados.");

        parcela.RegistrarPagamento();
        contaReceber.RegistrarPagamento(parcela.Valor);

        await this._parcelaRepository.UpdateAsync(parcela);
        await this._financeiroRepository.UpdateAsync(contaReceber);
        await this._unitOfWork.SaveChangesAsync();
        return parcela.Id;
    }
}
