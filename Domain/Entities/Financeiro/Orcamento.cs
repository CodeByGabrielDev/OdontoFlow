using Domain.Entities.Funcionarios;
using Domain.Entities.Pacientes;
namespace Domain.Entities.Financeiro;

public class Orcamento
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public Guid DentistaId{get;private set;}
    public Dentista Dentista{get;private set;}
    public string Descricao{get;private set;}
    public decimal ValorTotal{get;private set;}
    public bool Assinado{get;private set;}
    public DateTime? AssinadoEm{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private Orcamento(){ }
    public Orcamento(Guid pacienteId,Guid dentistaId,string descricao,decimal valorTotal)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.DentistaId = dentistaId;
        this.Descricao = descricao;
        this.ValorTotal = valorTotal;
        this.Assinado = false;
        this.CriadoEm = DateTime.UtcNow;
    }
}
