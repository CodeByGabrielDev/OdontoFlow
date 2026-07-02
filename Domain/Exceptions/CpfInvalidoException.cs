namespace Domain.Exceptions;

public class CpfInvalidoException : DomainException
{
    public CpfInvalidoException(string cpf):base($"Cpf '{cpf}' é invalido"){ }
}