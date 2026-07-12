using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Cro
{
    public string Uf{get;private set;}
    public string Numero{get;private set;}


    private Cro(){ }

    public Cro(string uf, string numero)
    {
        if (string.IsNullOrWhiteSpace(uf) || uf.Length != 2)
        {
            throw new UfInvalidaException(uf);
        }

        if (numero.Length >6)
        {
            throw new NumeroCroInvalidoException(numero);
        }
        foreach (char c in numero.ToCharArray())
        {
            if (!char.IsNumber(c))
            {
                throw new NumeroCroInvalidoException(numero); 
            }
        }
        this.Uf = uf.ToUpper();
        this.Numero = numero;
       
    }
}