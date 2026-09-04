using Application.Prontuarios.DTOs;
using MediatR;
namespace Application.Prontuarios.Queries.ObterProntuarioPorId;
public record ObterProntuarioPorIdQuery(Guid Id):IRequest<ProntuarioDto>;