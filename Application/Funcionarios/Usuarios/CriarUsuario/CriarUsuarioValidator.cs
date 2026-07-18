using FluentValidation;

namespace Application.Funcionarios.Usuarios.CriarUsuario;


public class CriarUsuarioValidator : AbstractValidator<CriarUsuarioCommand>
{

    public CriarUsuarioValidator()
    {
        RuleFor(x => x.Senha)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("Deve conter pelo menos uma letra maiúscula.")
                .Matches("[0-9]").WithMessage("Deve conter pelo menos um número.");
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x=>x.Perfil).NotEmpty();
    }
}