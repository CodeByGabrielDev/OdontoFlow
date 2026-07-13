using Domain.Entities.Pacientes;
 

namespace Domain.Entities.Pacientes;

public class Anamnese
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public string? Alergias{get;private set;}
    public string? MedicamentoEmUso{get;private set;}
    public string? DoencasSistemicas{get;private set;}
    public DateTime PreenchidaEm{get;private set;}
    private Anamnese(){ }
    public Anamnese(Guid pacienteId,string? alergias,string? medicamentoEmUso,string? doencasSistemicas)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.Alergias = alergias;
        this.MedicamentoEmUso = medicamentoEmUso;
        this.DoencasSistemicas = doencasSistemicas;
        this.PreenchidaEm = DateTime.UtcNow;
    }
    public Anamnese(Guid pacienteId)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.PreenchidaEm = DateTime.UtcNow;
    }

    /*
    public string? Alergias{get;private set;}
    public string? MedicamentoEmUso{get;private set;}
    public string? DoencasSistemicas{get;private set;}*/
    public void insereCamposEValidaParametros(string? alergias,string? medicamentoEmUso,string? doencasSistemicas)
    {
        if (!string.IsNullOrWhiteSpace(alergias))
        {
            this.Alergias = alergias;
        }
        if (!string.IsNullOrWhiteSpace(medicamentoEmUso))
        {
            this.MedicamentoEmUso = medicamentoEmUso;
        }
        if (!string.IsNullOrWhiteSpace(doencasSistemicas))
        {
            this.DoencasSistemicas =doencasSistemicas;
        }
    }

}