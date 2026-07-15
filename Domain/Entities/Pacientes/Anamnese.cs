using Domain.Entities.Pacientes;
 

namespace Domain.Entities.Pacientes;

public class Anamnese
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public List<Alergias> Alergias{get;private set;} // alterar para List
    public List<MedicamentoEmUso> MedicamentoEmUso{get;private set;} // alterar para List
    public List<DoencasSistemicas> DoencasSistemicas{get;private set;} // alterar para List
    public DateTime PreenchidaEm{get;private set;}
    
    private Anamnese(){ }
    public Anamnese(Guid pacienteId)
    {
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.Alergias = new List<Alergias>();
        this.MedicamentoEmUso = new List<MedicamentoEmUso>();
        this.DoencasSistemicas = new List<DoencasSistemicas>();
        this.PreenchidaEm = DateTime.UtcNow;
    }

    /*
    public string? Alergias{get;private set;}
    public string? MedicamentoEmUso{get;private set;}
    public string? DoencasSistemicas{get;private set;}*/
    
    public void insereInformacoesAlergias(List<string?> itens)
    {
        foreach (string item in itens)
        {
            this.Alergias.Add(new Pacientes.Alergias(this.Id,item));
        }
    }

    public void insereInformacoesMedicamentosEmUso(List<string?> itens)
    {
        foreach (string item in itens)
        {
            this.MedicamentoEmUso.Add(new Pacientes.MedicamentoEmUso(this.Id,item));
        }
    }

    public void insereInformacoesDoencasSistemicas(List<string?> itens)
    {
        foreach (string item in itens)
        {
            this.DoencasSistemicas.Add(new Pacientes.DoencasSistemicas(this.Id,item));
        }
    }
}