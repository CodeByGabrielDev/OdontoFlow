using Application.Financeiro.DTOs;
using Domain.Entities.Financeiro;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.ContasReceber.Queries.ObterContaReceberPorId;

public class ObterContaReceberPorIdHandler : IRequestHandler<ObterContaReceberPorIdQuery, ContaReceberDto>
{
    private readonly IFinanceiroRepository _financeiroRepository;

    public ObterContaReceberPorIdHandler(IFinanceiroRepository financeiroRepository)
    {
        this._financeiroRepository = financeiroRepository;
    }

    public async Task<ContaReceberDto> Handle(ObterContaReceberPorIdQuery query, CancellationToken cancellationToken)
    {
        ContaReceber? contaReceber = await this._financeiroRepository.ObterPorIdAsync(query.Id);
        if (contaReceber == null) throw new DomainException("Conta a receber nao encontrada na base de dados.");
        return ContaReceberDto.FromDomain(contaReceber);
    }
}
