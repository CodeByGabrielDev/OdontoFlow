using FluentValidation;

namespace Application.Financeiro.Parcelas.Commands.CriarParcela;

public class CriarParcelaValidator : AbstractValidator<CriarParcelaCommand>
{
    public CriarParcelaValidator()
    {
        RuleFor(entidade => entidade.ContaReceberId).NotEmpty();
        RuleFor(entidade => entidade.Numero).GreaterThan(0);
        RuleFor(entidade => entidade.Valor).GreaterThan(0);
    }
}
