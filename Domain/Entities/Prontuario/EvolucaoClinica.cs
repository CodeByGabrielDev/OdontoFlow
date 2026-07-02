using Domain.Entities.Agenda;
using Domain.Entities.Funcionarios;
namespace Domain.Entities.Prontuario;

public class EvolucaoClinica
{
    public Guid Id{get;private set;}
    public Guid ProntuarioId{get;private set;}
    public Prontuario Prontuario{get;private set;}
    public Guid DentistaId{get;private set;}
    public Dentista Dentista{get;private set;}
    public Guid ConsultaId{get;private set;}
    public Consulta Consulta{get;private set;}
    public string Descricao{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private EvolucaoClinica(){ }
    public EvolucaoClinica(Guid prontuarioId,Guid dentistaId,Guid consultaId,string descricao)
    {
        this.Id = Guid.NewGuid();
        this.ProntuarioId = prontuarioId;
        this.DentistaId = dentistaId;
        this.ConsultaId = consultaId;
        this.Descricao = descricao;
        this.CriadoEm = DateTime.UtcNow;
    }
}
