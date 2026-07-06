using Domain.Exceptions;
namespace Domain.ValueObjects;
public class Cpf
{
    public string Valor{get;private set;}

    private Cpf() { }

    public Cpf(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new CpfInvalidoException(valor);
        }
        if(valor.Length > 11)
        {
            throw new CpfInvalidoException(valor);
        }
        foreach(char c in valor.ToCharArray())
        {
            if (!char.IsNumber(c))
            {   
                throw new CpfInvalidoException(valor);
            }
        }
        this.Valor = valor;
    }
}