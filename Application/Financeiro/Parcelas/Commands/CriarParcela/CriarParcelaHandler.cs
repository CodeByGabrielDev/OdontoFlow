using Domain.Entities.Financeiro;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.Parcelas.Commands.CriarParcela;

public class CriarParcelaHandler : IRequestHandler<CriarParcelaCommand, Guid>
{
    private readonly IFinanceiroRepository _financeiroRepository;
    private readonly IParcelaRepository _parcelaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarParcelaHandler(IFinanceiroRepository financeiroRepository, IParcelaRepository parcelaRepository, IUnitOfWork unitOfWork)
    {
        this._financeiroRepository = financeiroRepository;
        this._parcelaRepository = parcelaRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CriarParcelaCommand command, CancellationToken cancellationToken)
    {
        ContaReceber? contaReceber = await this._financeiroRepository.ObterPorIdAsync(command.ContaReceberId);
        if (contaReceber == null) throw new DomainException("Conta a receber nao encontrada na base de dados.");

        Parcela parcela = new Parcela(command.ContaReceberId, command.Numero, command.Valor, command.Vencimento);
        await this._parcelaRepository.AddAsync(parcela);
        await this._unitOfWork.SaveChangesAsync();
        return parcela.Id;
    }
}
