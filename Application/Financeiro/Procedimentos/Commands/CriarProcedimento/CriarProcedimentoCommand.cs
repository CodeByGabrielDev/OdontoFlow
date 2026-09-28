using MediatR;

namespace Application.Financeiro.Procedimentos.Commands.CriarProcedimento;

public record CriarProcedimentoCommand(string Nome, decimal ValorBase, string? Descricao) : IRequest<Guid>;
