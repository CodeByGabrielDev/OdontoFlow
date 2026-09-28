using MediatR;

namespace Application.Financeiro.ContasReceber.Commands.CriarContaReceber;

public record CriarContaReceberCommand(Guid OrcamentoId) : IRequest<Guid>;
