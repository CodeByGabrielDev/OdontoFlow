using Application.Estoque.DTOs;
using MediatR;

namespace Application.Estoque.Itens.Queries.ListarItens;

public record ListarItensQuery() : IRequest<List<ItemEstoqueDto>>;
