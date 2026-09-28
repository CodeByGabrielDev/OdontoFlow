using Application.Funcionarios.Funcionario.DTOs;
using MediatR;

namespace Application.Funcionarios.Funcionario.Queries.ObterFuncionarioPorId;

public record ObterFuncionarioPorIdQuery(Guid Id) : IRequest<FuncionarioDto>;
