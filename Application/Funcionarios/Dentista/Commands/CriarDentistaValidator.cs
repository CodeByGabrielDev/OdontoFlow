using FluentValidation;

namespace Application.Funcionarios.Dentista.Commands;


public class CriarDentistaValidator : AbstractValidator<CriarDentistaCommand>
{
    public CriarDentistaValidator()
    {
        RuleFor(entidadeDentista => entidadeDentista.Nome).NotEmpty();
        RuleFor(entidadeDentista => entidadeDentista.NumeroCro).NotEmpty();
        RuleFor(entidadeDentista => entidadeDentista.UfCro).NotEmpty();
        RuleFor(entidadeDentista => entidadeDentista.Email).NotEmpty();
        RuleFor(entidadeDentista => entidadeDentista.Telefone).NotEmpty();
        RuleFor(entidadeDentista => entidadeDentista.Especialidade).NotEmpty();
    }
}