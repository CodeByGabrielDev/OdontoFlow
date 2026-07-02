using Domain.Entities.Pacientes;
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
    }
}
