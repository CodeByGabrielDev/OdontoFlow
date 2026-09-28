using Application.Financeiro.DTOs;
using MediatR;

namespace Application.Financeiro.Orcamentos.Queries.ObterOrcamentoPorId;

public record ObterOrcamentoPorIdQuery(Guid Id) : IRequest<OrcamentoDto>;
