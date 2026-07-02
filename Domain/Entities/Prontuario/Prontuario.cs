using Domain.Entities.Pacientes;

namespace Domain.Entities.Prontuario;

public class Prontuario
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public DateTime CriadoEm{get;private set;}

    private Prontuario(){ }

    public Prontuario(Guid pacienteId)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.CriadoEm = DateTime.UtcNow;
    }

}