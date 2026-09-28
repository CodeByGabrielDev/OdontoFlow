using Application.Convenios.DTOs;
using MediatR;

namespace Application.Convenios.Convenios.Queries.ListarConvenios;

public record ListarConveniosQuery() : IRequest<List<ConvenioDto>>;
