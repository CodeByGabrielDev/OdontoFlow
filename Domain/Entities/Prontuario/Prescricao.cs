using Domain.Entities.Funcionarios;
namespace Domain.Entities.Prontuario;

public class Prescricao
{
    public Guid Id{get;private set;}
    public Guid ProntuarioId{get;private set;}
    public Prontuario Prontuario{get;private set;}
    public Guid DentistaId{get;private set;}
    public Dentista Dentista{get;private set;}
    public string Medicamentos{get;private set;}
    public string? Instrucoes{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private Prescricao(){ }
    public Prescricao(Guid prontuarioId,Guid dentistaId,string medicamentos,string? instrucoes = null)
    {
        this.Id = Guid.NewGuid();
        this.ProntuarioId = prontuarioId;
        this.DentistaId = dentistaId;
        this.Medicamentos = medicamentos;
        this.Instrucoes = instrucoes;
        this.CriadoEm = DateTime.UtcNow;
    }
}
