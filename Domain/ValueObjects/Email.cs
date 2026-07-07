namespace Domain.ValueObjects;


public class Email
{
    public string Valor{get;private set;}

    private Email(){ }

    public Email(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new EmailInvalidoException(valor);
        }
        if (!valor.Contains("@"))
        {
            throw new EmailInvalidoException(valor);
        }

        this.Valor = valor;
    }
}