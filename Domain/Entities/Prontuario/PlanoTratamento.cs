using Domain.Entities.Funcionarios;
namespace Domain.Entities.Prontuario;

public class PlanoTratamento
{
    public Guid Id{get;private set;}
    public Guid ProntuarioId{get;private set;}
    public Prontuario Prontuario{get;private set;}
    public Guid DentistaId{get;private set;}
    public Dentista Dentista{get;private set;}
    public string Descricao{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private PlanoTratamento(){ }
    public PlanoTratamento(Guid prontuarioId,Guid dentistaId,string descricao)
    {
        this.Id = Guid.NewGuid();
        this.ProntuarioId = prontuarioId;
        this.DentistaId = dentistaId;
        this.Descricao = descricao;
        this.CriadoEm = DateTime.UtcNow;
    }
}