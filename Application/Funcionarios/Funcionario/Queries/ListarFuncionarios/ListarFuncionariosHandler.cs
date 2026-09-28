using Application.Funcionarios.Funcionario.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Funcionarios.Funcionario.Queries.ListarFuncionarios;

public class ListarFuncionariosHandler : IRequestHandler<ListarFuncionariosQuery, List<FuncionarioDto>>
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public ListarFuncionariosHandler(IFuncionarioRepository funcionarioRepository)
    {
        this._funcionarioRepository = funcionarioRepository;
    }

    public async Task<List<FuncionarioDto>> Handle(ListarFuncionariosQuery query, CancellationToken cancellationToken)
    {
        var funcionarios = await this._funcionarioRepository.ObterTodosAsync();
        return funcionarios.Select(FuncionarioDto.FromDomain).ToList();
    }
}
