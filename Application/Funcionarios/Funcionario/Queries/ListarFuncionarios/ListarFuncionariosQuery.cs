using Application.Funcionarios.Funcionario.DTOs;
using MediatR;

namespace Application.Funcionarios.Funcionario.Queries.ListarFuncionarios;

public record ListarFuncionariosQuery() : IRequest<List<FuncionarioDto>>;
