using Application.Financeiro.DTOs;
using MediatR;

namespace Application.Financeiro.Procedimentos.Queries.ListarProcedimentos;

public record ListarProcedimentosQuery() : IRequest<List<ProcedimentoDto>>;
