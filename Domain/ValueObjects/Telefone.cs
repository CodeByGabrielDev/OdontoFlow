namespace Domain.ValueObjects;


public class Telefone
{
    public string Valor { get; private set; }
    private Telefone() { }
    public Telefone(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException("telefone nao pode estar vazio");
        }
        if (valor.Length < 10 || valor.Length > 11)
        {
            throw new ArgumentException("Telefone invalido");
        }
        foreach (char c in valor.ToCharArray())
        {
            if (!char.IsNumber(c))
            {
                throw new ArgumentException("Telefone invalido");
            }
        }
        this.Valor = valor;
    }
}