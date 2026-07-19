using Domain.Entities.Agenda;
using Domain.ValueObjects;
namespace Domain.Entities.Funcionarios;

public class Dentista
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public List<Consulta?> Consultas { get; private set; }
    public List<ListaEspera> ListaEsperas { get; private set; }
    public List<GradeHorario> GradeHorarios { get; private set; }
    public Cro Cro { get; private set; }
    public Email Email { get; private set; }
    public Telefone Telefone { get; private set; }
    public string Especialidade { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime CriadoEm { get; private set; }
    private Dentista() { }
    public Dentista(string nome, Cro cro, Email email, Telefone telefone, string especialidade)
    {
        this.Id = Guid.NewGuid();
        this.Nome = nome;
        this.Cro = cro;
        this.Email = email;
        this.Telefone = telefone;
        this.Especialidade = especialidade;
        this.Ativo = true;
        this.CriadoEm = DateTime.UtcNow;
        this.Consultas = new List<Consulta?>();
        this.ListaEsperas = new List<ListaEspera>();
        this.GradeHorarios = new List<GradeHorario>();
    }
}
