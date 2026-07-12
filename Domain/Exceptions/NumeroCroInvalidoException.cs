namespace Domain.Exceptions;


public class NumeroCroInvalidoException:DomainException
{
    public NumeroCroInvalidoException(string numero):base($"o numero: '{numero}' não segue os padroes estipulados"){ }
}