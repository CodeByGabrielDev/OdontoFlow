using Application.Consultas.DTOs;

namespace Application.Funcionarios.Dentista.DTOs;


public class DentistaDto
{
    public string Nome { get; private set; }
    public List<ConsultaDto> ConsultaDtos { get; private set; }
    public string UfCro { get; private set; }
    public string NumeroCro { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string Especialidade { get; private set; }
    public bool Ativo { get; private set; }

    private DentistaDto() { }
    public DentistaDto(string nome, string ufCro, string numeroCro, string email, string telefone, string especialidade, bool ativo)
    {
        this.Nome = nome;
        this.ConsultaDtos = new List<ConsultaDto>();
        this.UfCro = ufCro;
        this.NumeroCro = numeroCro;
        this.Email = email;
        this.Telefone = telefone;
        this.Especialidade = especialidade;
        this.Ativo = ativo;
    }

}