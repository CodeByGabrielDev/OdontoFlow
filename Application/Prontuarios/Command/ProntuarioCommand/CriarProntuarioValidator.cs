using Application.Prontuarios.Command.ProntuarioCommand;
using FluentValidation;

namespace Application.Prontuarios.Command;


public class CriarProntuarioValidator : AbstractValidator<CriarProntuarioCommand>
{
    public CriarProntuarioValidator()
    {
        RuleFor(entidadeCriarProntuario=>entidadeCriarProntuario.IdPaciente).NotNull();
        RuleFor(entidadeCriarProntuario=>entidadeCriarProntuario.IdPaciente).NotEmpty();
    }
}