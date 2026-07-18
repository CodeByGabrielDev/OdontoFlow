using FluentValidation;

namespace Application.Agenda.ListaEspera.Commands.CriarListaDeEspera;


public class CriarListaDeesperaValidator : AbstractValidator<CriarListaDeEsperaCommand>
{
    public CriarListaDeesperaValidator()
    {
        RuleFor(entidadeCommand=>entidadeCommand.PacienteId).NotEmpty();
        RuleFor(entidadeCommand=>entidadeCommand.DentistaId).NotEmpty();
    }
}