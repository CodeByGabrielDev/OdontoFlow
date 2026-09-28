using Application.Estoque.DTOs;
using MediatR;

namespace Application.Estoque.Itens.Queries.ListarItensAbaixoMinimo;

public record ListarItensAbaixoMinimoQuery() : IRequest<List<ItemEstoqueDto>>;
