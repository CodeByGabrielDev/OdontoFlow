using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities.Funcionarios;


public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public string SenhaHash { get; private set; }
    public TipoPerfil Perfil { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime CriadoEm { get; private set; }


    private Usuario() { }
    public Usuario(string nome, Email email, string senhaHash, TipoPerfil perfil)
    {
        this.Nome = nome;
        this.SenhaHash = senhaHash;
        this.Perfil = perfil;
        this.Email = email;
        this.Ativo = true;

    }
}