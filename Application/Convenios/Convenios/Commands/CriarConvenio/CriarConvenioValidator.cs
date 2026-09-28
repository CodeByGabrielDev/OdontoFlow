using FluentValidation;

namespace Application.Convenios.Convenios.Commands.CriarConvenio;

public class CriarConvenioValidator : AbstractValidator<CriarConvenioCommand>
{
    public CriarConvenioValidator()
    {
        RuleFor(entidade => entidade.Nome).NotEmpty().MaximumLength(200);
        RuleFor(entidade => entidade.Operadora).NotEmpty().MaximumLength(200);
    }
}
