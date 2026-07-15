using FluentValidation;

namespace Application.Pacientes.Commands.AtualizarPaciente;


public class AtualizarPacienteValidator : AbstractValidator<AtualizarPacienteCommand>
{
    public AtualizarPacienteValidator()
    {
        RuleFor(x=>x.Id).NotEmpty();
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Telefone).NotEmpty();
        RuleFor(x => x.DataNascimento).NotEmpty().LessThan(DateTime.Today);
        RuleFor(x => x.Sexo).NotEmpty();
        RuleFor(x => x.Endereco).NotEmpty();
    }
}