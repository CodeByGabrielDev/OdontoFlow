using Domain.Entities.Pacientes;
using Domain.Entities.Funcionarios;
namespace Domain.Entities.Agenda;
public class ListaEspera
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public Guid DentistaId{get;private set;}
    public Dentista Dentista{get;private set;}
    public DateTime DataSolicitacao{get;private set;}
    public string? Observacao{get;private set;}
    private ListaEspera(){ }
    public ListaEspera(Guid pacienteId,Guid dentistaId,string? observacao)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.DentistaId = dentistaId;
        this.DataSolicitacao = DateTime.UtcNow;
        this.Observacao = observacao;
    }
}