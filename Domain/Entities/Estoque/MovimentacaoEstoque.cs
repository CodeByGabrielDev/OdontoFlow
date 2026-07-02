using Domain.Enums;
namespace Domain.Entities.Estoque;

public class MovimentacaoEstoque
{
    public Guid Id{get;private set;}
    public Guid ItemEstoqueId{get;private set;}
    public ItemEstoque ItemEstoque{get;private set;}
    public TipoMovimentacao Tipo{get;private set;}
    public int Quantidade{get;private set;}
    public string? Observacao{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private MovimentacaoEstoque(){ }
    public MovimentacaoEstoque(Guid itemEstoqueId,TipoMovimentacao tipo,int quantidade,string? observacao = null)
    {
        this.Id = Guid.NewGuid();
        this.ItemEstoqueId = itemEstoqueId;
        this.Tipo = tipo;
        this.Quantidade = quantidade;
        this.Observacao = observacao;
        this.CriadoEm = DateTime.UtcNow;
    }
}
