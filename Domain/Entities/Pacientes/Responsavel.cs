using Domain.ValueObjects;

namespace Domain.Entities.Pacientes;
public class Responsavel
{
    public Guid Id{get;private set;}
    public List<Paciente> Pacientes{get;private set;}
    public string Nome{get;private set;}
    public Cpf Cpf{get;private set;}
    public Telefone Telefone{get;private set;}
    public string Parentesco{get; private set;}
    private Responsavel(){}
    public Responsavel(string nome,Cpf cpf,Telefone telefone,string parentesco)
    {   
        this.Id = Guid.NewGuid();
        this.Pacientes = new List<Paciente>();
        this.Nome = nome;
        this.Cpf = cpf;
        this.Telefone = telefone;
        this.Parentesco = parentesco;
    }
}