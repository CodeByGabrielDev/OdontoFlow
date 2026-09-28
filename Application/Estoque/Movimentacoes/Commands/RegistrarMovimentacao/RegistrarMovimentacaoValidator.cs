using FluentValidation;

namespace Application.Estoque.Movimentacoes.Commands.RegistrarMovimentacao;

public class RegistrarMovimentacaoValidator : AbstractValidator<RegistrarMovimentacaoCommand>
{
    public RegistrarMovimentacaoValidator()
    {
        RuleFor(entidade => entidade.ItemEstoqueId).NotEmpty();
        RuleFor(entidade => entidade.Quantidade).GreaterThan(0);
    }
}
