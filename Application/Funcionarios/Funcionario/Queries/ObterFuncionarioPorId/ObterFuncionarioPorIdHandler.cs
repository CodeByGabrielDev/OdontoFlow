using Application.Funcionarios.Funcionario.DTOs;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Funcionarios.Funcionario.Queries.ObterFuncionarioPorId;

public class ObterFuncionarioPorIdHandler : IRequestHandler<ObterFuncionarioPorIdQuery, FuncionarioDto>
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public ObterFuncionarioPorIdHandler(IFuncionarioRepository funcionarioRepository)
    {
        this._funcionarioRepository = funcionarioRepository;
    }

    public async Task<FuncionarioDto> Handle(ObterFuncionarioPorIdQuery query, CancellationToken cancellationToken)
    {
        var funcionario = await this._funcionarioRepository.ObterPorIdAsync(query.Id);
        if (funcionario == null) throw new DomainException("Funcionario nao encontrado na base de dados.");
        return FuncionarioDto.FromDomain(funcionario);
    }
}
