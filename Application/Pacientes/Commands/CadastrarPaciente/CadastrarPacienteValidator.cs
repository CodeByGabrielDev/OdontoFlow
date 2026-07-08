using FluentValidation;

namespace Application.Pacientes.Commands.CadastrarPaciente;

public class CadastrarPacienteValidator : AbstractValidator<CadastrarPacienteCommand>
{
    public CadastrarPacienteValidator()
    {
        RuleFor(x=>x.Nome).NotEmpty().MaximumLength(200);
        RuleFor(x=>x.Cpf).NotEmpty().Length(11);
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
        RuleFor(x=>x.Telefone).NotEmpty();
        RuleFor(x=>x.DataNascimento).NotEmpty().LessThan(DateTime.Today);
        RuleFor(x => x.Sexo).NotEmpty();
        RuleFor(x => x.Endereco).NotEmpty();

    }
}
