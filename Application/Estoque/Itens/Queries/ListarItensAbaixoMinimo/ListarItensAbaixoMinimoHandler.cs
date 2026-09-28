using Application.Estoque.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Estoque.Itens.Queries.ListarItensAbaixoMinimo;

public class ListarItensAbaixoMinimoHandler : IRequestHandler<ListarItensAbaixoMinimoQuery, List<ItemEstoqueDto>>
{
    private readonly IEstoqueRepository _estoqueRepository;

    public ListarItensAbaixoMinimoHandler(IEstoqueRepository estoqueRepository)
    {
        this._estoqueRepository = estoqueRepository;
    }

    public async Task<List<ItemEstoqueDto>> Handle(ListarItensAbaixoMinimoQuery query, CancellationToken cancellationToken)
    {
        var itens = await this._estoqueRepository.ObterAbaixoMinimoAsync();
        return itens.Select(ItemEstoqueDto.FromDomain).ToList();
    }
}
