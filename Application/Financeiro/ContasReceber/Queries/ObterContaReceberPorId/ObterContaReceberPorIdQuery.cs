using Application.Financeiro.DTOs;
using MediatR;

namespace Application.Financeiro.ContasReceber.Queries.ObterContaReceberPorId;

public record ObterContaReceberPorIdQuery(Guid Id) : IRequest<ContaReceberDto>;
