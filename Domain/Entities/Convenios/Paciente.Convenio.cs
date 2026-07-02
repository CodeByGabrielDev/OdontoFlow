using Domain.Entities.Pacientes;
namespace Domain.Entities.Convenios;

public class PacienteConvenio
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public Guid ConvenioId{get;private set;}
    public Convenio Convenio{get;private set;}
    public string NumeroCarteirinha{get;private set;}
    public DateTime Validade{get;private set;}
    private PacienteConvenio(){ }
    public PacienteConvenio(Guid pacienteId,Guid convenioId,string numeroCarteirinha,DateTime validade)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.ConvenioId = convenioId;
        this.NumeroCarteirinha = numeroCarteirinha;
        this.Validade = validade;
    }
}
