namespace Domain.Exceptions;

public class EmailInvalidoException:DomainException
{
    public EmailInvalidoException(string email):base($"o email: '{email}' nao segue os padroes estipulados"){}
}