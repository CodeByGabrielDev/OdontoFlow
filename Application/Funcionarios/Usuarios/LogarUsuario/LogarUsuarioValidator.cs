using FluentValidation;

namespace Application.Funcionarios.Usuarios.LogarUsuario;

public class LogarUsuarioValidator : AbstractValidator<LogarUsuarioCommand>
{
    public LogarUsuarioValidator()
    {
        RuleFor(entidadeLogin => entidadeLogin.Email).NotEmpty();
        RuleFor(entidadeLogin => entidadeLogin.Senha).NotEmpty();
    }
}