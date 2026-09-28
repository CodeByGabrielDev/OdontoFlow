using MediatR;

namespace Application.Financeiro.Orcamentos.Commands.CriarOrcamento;

public record CriarOrcamentoCommand(Guid PacienteId, Guid DentistaId, string Descricao, decimal ValorTotal) : IRequest<Guid>;
