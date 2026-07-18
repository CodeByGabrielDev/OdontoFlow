using Application.Consultas.CriarConsulta;
using FluentValidation;

namespace Application.Agenda.Consultas.CriarConsulta;


public class CriarConsultaValidation : AbstractValidator<CriarConsultaCommand>
{
    
    public CriarConsultaValidation()
    {
        RuleFor(entidade=>entidade.PacienteId).NotEmpty();
        RuleFor(entidade=>entidade.DentistaId).NotEmpty();
        RuleFor(entidade=>entidade.Data).NotEmpty();
        RuleFor(entidade=>entidade.HoraInicio).NotEmpty();
        RuleFor(entidade=>entidade.HoraFim).NotEmpty();
    }
}