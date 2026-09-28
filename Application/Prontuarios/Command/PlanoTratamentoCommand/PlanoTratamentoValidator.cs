using FluentValidation;

namespace Application.Prontuarios.Command.PlanoTratamentoCommand;

public class PlanoTratamentoValidator : AbstractValidator<PlanoTratamentoCommand>
{
    public PlanoTratamentoValidator()
    {
        RuleFor(entidade => entidade.ProntuarioId).NotEmpty();
        RuleFor(entidade => entidade.DentistaId).NotEmpty();
        RuleFor(entidade => entidade.Descricao).NotEmpty();
    }
}
