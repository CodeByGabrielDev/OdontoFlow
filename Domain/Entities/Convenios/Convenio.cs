namespace Domain.Entities.Convenios;

public class Convenio
{
    public Guid Id{get;private set;}
    public string Nome{get;private set;}
    public string Operadora{get;private set;}
    public bool Ativo{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private Convenio(){ }
    public Convenio(string nome,string operadora)
    {
        this.Id = Guid.NewGuid();
        this.Nome = nome;
        this.Operadora = operadora;
        this.Ativo = true;
        this.CriadoEm = DateTime.UtcNow;
    }
}
