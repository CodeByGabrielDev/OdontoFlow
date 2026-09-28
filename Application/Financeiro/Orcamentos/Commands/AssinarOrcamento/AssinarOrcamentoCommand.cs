using MediatR;

namespace Application.Financeiro.Orcamentos.Commands.AssinarOrcamento;

public record AssinarOrcamentoCommand(Guid OrcamentoId) : IRequest<Guid>;
