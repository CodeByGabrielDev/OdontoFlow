namespace Domain.Entities.Financeiro;

public class Procedimento
{
    public Guid Id{get;private set;}
    public string Nome{get;private set;}
    public string? Descricao{get;private set;}
    public decimal ValorBase{get;private set;}
    private Procedimento(){ }
    public Procedimento(string nome,decimal valorBase,string? descricao = null)
    {
        this.Id = Guid.NewGuid();
        this.Nome = nome;
        this.ValorBase = valorBase;
        this.Descricao = descricao;
    }
}
