using FluentValidation;

namespace Application.Financeiro.Procedimentos.Commands.CriarProcedimento;

public class CriarProcedimentoValidator : AbstractValidator<CriarProcedimentoCommand>
{
    public CriarProcedimentoValidator()
    {
        RuleFor(entidade => entidade.Nome).NotEmpty().MaximumLength(200);
        RuleFor(entidade => entidade.ValorBase).GreaterThan(0);
    }
}
