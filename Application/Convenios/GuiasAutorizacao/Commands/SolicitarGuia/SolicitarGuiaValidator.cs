using FluentValidation;

namespace Application.Convenios.GuiasAutorizacao.Commands.SolicitarGuia;

public class SolicitarGuiaValidator : AbstractValidator<SolicitarGuiaCommand>
{
    public SolicitarGuiaValidator()
    {
        RuleFor(entidade => entidade.PacienteId).NotEmpty();
        RuleFor(entidade => entidade.ConvenioId).NotEmpty();
        RuleFor(entidade => entidade.ProcedimentoId).NotEmpty();
    }
}
