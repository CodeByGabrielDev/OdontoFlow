using Domain.Entities.Agenda;
using Domain.ValueObjects;

namespace Domain.Entities.Pacientes;

public class Paciente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public List<Consulta?>Consultas{get;private set;}
    public Guid? ResponsavelId{get;private set;}
    public Responsavel? Responsavel{get;private set;}
    public Cpf Cpf { get; private set; }
    public Email Email { get; private set; }
    public Telefone Telefone { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Sexo { get; private set; }
    public string Endereco { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime CriadoEm { get; private set; }
    private Paciente(){ }
    public Paciente(string nome, Cpf cpf, Email email, Telefone telefone,
                    DateTime dataNascimento, string sexo, string endereco)
    {
        this.Id = Guid.NewGuid();
        this.Nome = nome;
        this.Cpf = cpf;
        this.Email = email;
        this.Telefone = telefone;
        this.DataNascimento = dataNascimento;
        this.Sexo = sexo;
        this.Endereco = endereco;
        this.Consultas = new List<Consulta?>();
        this.Ativo = true;
        this.CriadoEm = DateTime.UtcNow;
    }
    public void AtualizarDados(string? nome,
    string? email,string? telefone,
    string? sexo, string? endereco)
    {
        if (!string.IsNullOrWhiteSpace(nome))
        {
            this.Nome = nome;
        }
        if (!string.IsNullOrWhiteSpace(email))
        {
            Email emailEntity = new Email(email);
            this.Email = emailEntity;
        }
        if (!string.IsNullOrWhiteSpace(telefone))
        {
            Telefone telefoneEntity = new Telefone(telefone);
            this.Telefone = telefoneEntity;
        }
        if (!string.IsNullOrWhiteSpace(sexo))
        {
            this.Sexo = sexo;
        }
        if (!string.IsNullOrWhiteSpace(endereco))
        {
            this.Endereco = endereco;
        }
    }
   
}