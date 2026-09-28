using Application.Financeiro.DTOs;
using Domain.Entities.Financeiro;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Financeiro.Orcamentos.Queries.ObterOrcamentoPorId;

public class ObterOrcamentoPorIdHandler : IRequestHandler<ObterOrcamentoPorIdQuery, OrcamentoDto>
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public ObterOrcamentoPorIdHandler(IOrcamentoRepository orcamentoRepository)
    {
        this._orcamentoRepository = orcamentoRepository;
    }

    public async Task<OrcamentoDto> Handle(ObterOrcamentoPorIdQuery query, CancellationToken cancellationToken)
    {
        Orcamento? orcamento = await this._orcamentoRepository.ObterPorIdAsync(query.Id);
        if (orcamento == null) throw new DomainException("Orcamento nao encontrado na base de dados.");
        return OrcamentoDto.FromDomain(orcamento);
    }
}
