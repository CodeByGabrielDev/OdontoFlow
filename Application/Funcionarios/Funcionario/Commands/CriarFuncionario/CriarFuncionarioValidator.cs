using FluentValidation;

namespace Application.Funcionarios.Funcionario.Commands.CriarFuncionario;

public class CriarFuncionarioValidator : AbstractValidator<CriarFuncionarioCommand>
{
    public CriarFuncionarioValidator()
    {
        RuleFor(entidade => entidade.Nome).NotEmpty().MaximumLength(200);
        RuleFor(entidade => entidade.Email).NotEmpty();
        RuleFor(entidade => entidade.Telefone).NotEmpty();
    }
}
