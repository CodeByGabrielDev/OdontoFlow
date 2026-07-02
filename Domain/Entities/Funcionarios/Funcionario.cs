using Domain.Enums;
using Domain.ValueObjects;
namespace Domain.Entities.Funcionarios;

public class Funcionario
{
    public Guid Id{get;private set;}
    public string Nome{get;private set;}
    public Email Email{get;private set;}
    public Telefone Telefone{get;private set;}
    public TipoPerfil Perfil{get;private set;}
    public bool Ativo{get;private set;}
    public DateTime CriadoEm{get;private set;}
    private Funcionario(){ }
    public Funcionario(string nome,Email email,Telefone telefone,TipoPerfil perfil)
    {
        this.Id = Guid.NewGuid();
        this.Nome = nome;
        this.Email = email;
        this.Telefone = telefone;
        this.Perfil = perfil;
        this.Ativo = true;
        this.CriadoEm = DateTime.UtcNow;
    }
}
