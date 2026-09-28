using FluentValidation;

namespace Application.Financeiro.ContasReceber.Commands.CriarContaReceber;

public class CriarContaReceberValidator : AbstractValidator<CriarContaReceberCommand>
{
    public CriarContaReceberValidator()
    {
        RuleFor(entidade => entidade.OrcamentoId).NotEmpty();
    }
}
