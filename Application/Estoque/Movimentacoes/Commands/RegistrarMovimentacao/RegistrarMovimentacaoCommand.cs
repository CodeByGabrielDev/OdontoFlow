using Domain.Enums;
using MediatR;

namespace Application.Estoque.Movimentacoes.Commands.RegistrarMovimentacao;

public record RegistrarMovimentacaoCommand(Guid ItemEstoqueId, TipoMovimentacao Tipo, int Quantidade, string? Observacao) : IRequest<Guid>;
