using MediatR;

namespace Application.Estoque.Itens.Commands.CriarItemEstoque;

public record CriarItemEstoqueCommand(string Nome, int QuantidadeMinima, string? Descricao, DateTime? Validade) : IRequest<Guid>;
