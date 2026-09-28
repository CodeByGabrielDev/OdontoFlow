using FluentValidation;

namespace Application.Financeiro.Orcamentos.Commands.CriarOrcamento;

public class CriarOrcamentoValidator : AbstractValidator<CriarOrcamentoCommand>
{
    public CriarOrcamentoValidator()
    {
        RuleFor(entidade => entidade.PacienteId).NotEmpty();
        RuleFor(entidade => entidade.DentistaId).NotEmpty();
        RuleFor(entidade => entidade.Descricao).NotEmpty();
        RuleFor(entidade => entidade.ValorTotal).GreaterThan(0);
    }
}
