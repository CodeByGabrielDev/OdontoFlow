using Domain.Entities.Pacientes;

namespace Domain.Entities.Prontuario;

public class Prontuario
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public DateTime CriadoEm{get;private set;}
    public Odontograma Odontograma{get;private set;}
    public List<EvolucaoClinica> EvolucaoClinicas{get;private set;}
    public List<PlanoTratamento> PlanosTratamento{get;private set;}
    public List<Prescricao> Prescricoes{get;private set;}
    private Prontuario(){ }

    public Prontuario(Guid pacienteId)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.CriadoEm = DateTime.UtcNow;
        this.EvolucaoClinicas = new List<EvolucaoClinica>();
        this.PlanosTratamento = new List<PlanoTratamento>();
        this.Prescricoes = new List<Prescricao>();
    }

}