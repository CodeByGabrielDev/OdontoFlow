using FluentValidation;

namespace Application.Prontuarios.Command.PrescricaoCommand;

public class PrescricaoValidator : AbstractValidator<PrescricaoCommand>
{
    public PrescricaoValidator()
    {
        RuleFor(entidade => entidade.ProntuarioId).NotEmpty();
        RuleFor(entidade => entidade.DentistaId).NotEmpty();
        RuleFor(entidade => entidade.Medicamentos).NotEmpty();
    }
}
