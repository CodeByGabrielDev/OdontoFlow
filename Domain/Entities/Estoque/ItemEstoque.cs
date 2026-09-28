using Domain.Exceptions;

namespace Domain.Entities.Estoque;

public class ItemEstoque
{
    public Guid Id{get;private set;}
    public string Nome{get;private set;}
    public string? Descricao{get;private set;}
    public int QuantidadeAtual{get;private set;}
    public int QuantidadeMinima{get;private set;}
    public DateTime? Validade{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private ItemEstoque(){ }
    public ItemEstoque(string nome,int quantidadeMinima,string? descricao = null,DateTime? validade = null)
    {
        this.Id = Guid.NewGuid();
        this.Nome = nome;
        this.QuantidadeMinima = quantidadeMinima;
        this.Descricao = descricao;
        this.QuantidadeAtual = 0;
        this.Validade = validade;
        this.CriadoEm = DateTime.UtcNow;
    }

    public void RegistrarEntrada(int quantidade)
    {
        if (quantidade <= 0)
            throw new DomainException("Quantidade de entrada deve ser maior que zero.");
        this.QuantidadeAtual += quantidade;
    }

    public void RegistrarSaida(int quantidade)
    {
        if (quantidade <= 0)
            throw new DomainException("Quantidade de saida deve ser maior que zero.");
        if (quantidade > this.QuantidadeAtual)
            throw new DomainException("Saldo insuficiente em estoque para essa saida.");
        this.QuantidadeAtual -= quantidade;
    }
}
