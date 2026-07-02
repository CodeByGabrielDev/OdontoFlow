namespace Domain.Entities.Financeiro;

public class Parcela
{
    public Guid Id{get;private set;}
    public Guid ContaReceberId{get;private set;}
    public ContaReceber ContaReceber{get;private set;}
    public int Numero{get;private set;}
    public decimal Valor{get;private set;}
    public DateTime Vencimento{get;private set;}
    public DateTime? PagoEm{get;private set;}
    public bool Pago{get;private set;}
    private Parcela(){ }
    public Parcela(Guid contaReceberId,int numero,decimal valor,DateTime vencimento)
    {
        this.Id = Guid.NewGuid();
        this.ContaReceberId = contaReceberId;
        this.Numero = numero;
        this.Valor = valor;
        this.Vencimento = vencimento;
        this.Pago = false;
    }
}
