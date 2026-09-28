using FluentValidation;

namespace Application.Estoque.Itens.Commands.CriarItemEstoque;

public class CriarItemEstoqueValidator : AbstractValidator<CriarItemEstoqueCommand>
{
    public CriarItemEstoqueValidator()
    {
        RuleFor(entidade => entidade.Nome).NotEmpty().MaximumLength(200);
        RuleFor(entidade => entidade.QuantidadeMinima).GreaterThanOrEqualTo(0);
    }
}
