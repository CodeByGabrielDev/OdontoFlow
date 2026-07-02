namespace Domain.Exceptions;

public class ConflitoAgendaException : DomainException
{
    public ConflitoAgendaException():base("Ja existe uma consulta agendada para esse horario"){}
}