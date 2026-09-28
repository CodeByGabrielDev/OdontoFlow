using Domain.Entities.Pacientes;
using Domain.Exceptions;
namespace Domain.Entities.Financeiro;

public class ContaReceber
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public Guid OrcamentoId{get;private set;}
    public Orcamento Orcamento{get;private set;}
    public decimal ValorTotal{get;private set;}
    public decimal ValorPago{get;private set;}
    public bool Pago{get;private set;}
    public DateTime CriadoEm{get;private set;}
    public List<Parcela> Parcelas{get;private set;}
    private ContaReceber(){ }
    public ContaReceber(Guid pacienteId,Guid orcamentoId,decimal valorTotal)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.OrcamentoId = orcamentoId;
        this.ValorTotal = valorTotal;
        this.ValorPago = 0;
        this.Pago = false;
        this.CriadoEm = DateTime.UtcNow;
        this.Parcelas = new List<Parcela>();
    }

    public void RegistrarPagamento(decimal valor)
    {
        if (this.Pago)
            throw new DomainException("Conta a receber ja esta quitada.");
        if (valor <= 0)
            throw new DomainException("Valor de pagamento deve ser maior que zero.");
        this.ValorPago += valor;
        if (this.ValorPago >= this.ValorTotal)
            this.Pago = true;
    }
}
