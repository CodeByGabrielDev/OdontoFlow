using Domain.Entities.Convenios;

namespace Application.Convenios.DTOs;

public class ConvenioDto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Operadora { get; private set; } = string.Empty;
    public bool Ativo { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private ConvenioDto() { }

    public static ConvenioDto FromDomain(Convenio convenio)
    {
        return new ConvenioDto
        {
            Id = convenio.Id,
            Nome = convenio.Nome,
            Operadora = convenio.Operadora,
            Ativo = convenio.Ativo,
            CriadoEm = convenio.CriadoEm
        };
    }
}
