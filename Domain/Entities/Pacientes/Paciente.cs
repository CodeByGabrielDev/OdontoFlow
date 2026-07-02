using Domain.ValueObjects.Cpf;
using Domain.ValueObjects.Email;
using Domain.ValueObjects.Telefone;

namespace Domain.Entities.Pacientes;

public class Paciente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
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
        this.Ativo = true;
        this.CriadoEm = DateTime.UtcNow;
    }
}