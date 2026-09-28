using FluentValidation;

namespace Application.Convenios.PacienteConvenios.Commands.VincularPacienteConvenio;

public class VincularPacienteConvenioValidator : AbstractValidator<VincularPacienteConvenioCommand>
{
    public VincularPacienteConvenioValidator()
    {
        RuleFor(entidade => entidade.PacienteId).NotEmpty();
        RuleFor(entidade => entidade.ConvenioId).NotEmpty();
        RuleFor(entidade => entidade.NumeroCarteirinha).NotEmpty();
    }
}
