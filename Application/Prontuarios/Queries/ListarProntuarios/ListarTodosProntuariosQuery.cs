using Application.Prontuarios.DTOs;
using MediatR;

namespace Application.Prontuarios.Queries.ListarProntuarios;


public record ListarTodosProntuariosQuery():IRequest<List<ProntuarioDto>>;