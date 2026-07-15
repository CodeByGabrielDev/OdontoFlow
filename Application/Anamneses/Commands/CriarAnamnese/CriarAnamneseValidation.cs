using FluentValidation;

namespace Application.Anamneses.Commands.CriarAnamnese;


public class CriarAnamneseValidation : AbstractValidator<CriarAnamneseCommand>
{
    public CriarAnamneseValidation()
    {
        RuleFor(entidadeCommand=>entidadeCommand.PacienteId).NotEmpty();        
    }
}