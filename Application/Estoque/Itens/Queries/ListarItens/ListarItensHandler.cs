using Application.Estoque.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Estoque.Itens.Queries.ListarItens;

public class ListarItensHandler : IRequestHandler<ListarItensQuery, List<ItemEstoqueDto>>
{
    private readonly IEstoqueRepository _estoqueRepository;

    public ListarItensHandler(IEstoqueRepository estoqueRepository)
    {
        this._estoqueRepository = estoqueRepository;
    }

    public async Task<List<ItemEstoqueDto>> Handle(ListarItensQuery query, CancellationToken cancellationToken)
    {
        var itens = await this._estoqueRepository.ObterTodosAsync();
        return itens.Select(ItemEstoqueDto.FromDomain).ToList();
    }
}
