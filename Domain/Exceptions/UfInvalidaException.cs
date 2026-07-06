namespace Domain.Exceptions;


public class UfInvalidaException:DomainException
{
    public UfInvalidaException(string uf):base($"a UF '{uf}' não segue os padroes estipulados");
}