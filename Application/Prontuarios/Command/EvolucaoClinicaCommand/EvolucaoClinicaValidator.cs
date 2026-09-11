using FluentValidation;

namespace Application.Prontuarios.Command.EvolucaoClinicaCommand;

public class EvolucaoClinicaValidator : AbstractValidator<EvolucaoClinicaCommand>
{
    public EvolucaoClinicaValidator()
    {
        RuleFor(entidade=>entidade.DentistaId).NotEmpty();
        RuleFor(entidade=>entidade.ProntuarioId).NotEmpty();
        RuleFor(entidade=>entidade.ConsultaId).NotEmpty();
        
    }
}