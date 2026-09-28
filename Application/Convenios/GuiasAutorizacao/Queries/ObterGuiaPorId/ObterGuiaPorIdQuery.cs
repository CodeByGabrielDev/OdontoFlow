using Application.Convenios.DTOs;
using MediatR;

namespace Application.Convenios.GuiasAutorizacao.Queries.ObterGuiaPorId;

public record ObterGuiaPorIdQuery(Guid Id) : IRequest<GuiaAutorizacaoDto>;
