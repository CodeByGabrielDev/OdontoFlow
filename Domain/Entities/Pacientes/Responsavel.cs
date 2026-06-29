using Domain.ValueObjects.Cpf;
using Domain.ValueObjects.Telefone;
namespace Domain.Entities.Pacientes;
public class Responsavel
{
    public Guid Id{get;private set;}
    public Guid PacienteId{get;private set;}
    public Paciente Paciente{get;private set;}
    public string Nome{get;private set;}
    public Cpf Cpf{get;private set;}
    public Telefone Telefone{get;private set;}
    public string Parentesco{get; private set;}
    private Responsavel(){}
    public Responsavel(Guid pacienteId,string nome,Cpf cpf,Telefone telefone,string parentesco)
    {   
        this.Id = Guid.NewGuid();
        this.PacienteId = pacienteId;
        this.Nome = nome;
        this.Cpf = cpf;
        this.Telefone = telefone;
        this.Parentesco = parentesco;
    }
}