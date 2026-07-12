using Domain.Entities.Financeiro;
using Domain.Entities.Pacientes;
using Domain.Enums;
namespace Domain.Entities.Convenios;

public class GuiaAutorizacao
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public Guid ConvenioId{get;private set;}
    public Convenio Convenio{get;private set;}
    public Guid ProcedimentoId{get;private set;}
    public Procedimento Procedimento{get;private set;}
    public StatusGuia Status{get;private set;}
    public string? Observacao{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private GuiaAutorizacao(){ }
    public GuiaAutorizacao(Guid pacienteId,Guid convenioId,Guid procedimentoId,string? observacao = null)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.ConvenioId = convenioId;
        this.ProcedimentoId = procedimentoId;
        this.Status = StatusGuia.Solicitado;
        this.Observacao = observacao;
        this.CriadoEm = DateTime.UtcNow;
    }
}
