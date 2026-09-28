using Domain.Entities.Funcionarios;

namespace Application.Funcionarios.Funcionario.DTOs;

public class FuncionarioDto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Telefone { get; private set; } = string.Empty;
    public string Perfil { get; private set; } = string.Empty;
    public bool Ativo { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private FuncionarioDto() { }

    public static FuncionarioDto FromDomain(Domain.Entities.Funcionarios.Funcionario funcionario)
    {
        return new FuncionarioDto
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Email = funcionario.Email.Valor,
            Telefone = funcionario.Telefone.Valor,
            Perfil = funcionario.Perfil.ToString(),
            Ativo = funcionario.Ativo,
            CriadoEm = funcionario.CriadoEm
        };
    }
}
