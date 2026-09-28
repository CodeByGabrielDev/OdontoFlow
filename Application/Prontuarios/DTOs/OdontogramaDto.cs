using Domain.Entities.Prontuario;

namespace Application.Prontuarios.DTOs;

public class OdontogramaDto
{
    public Guid Id { get; private set; }
    public List<DenteDto> Dentes { get; private set; } = new();

    private OdontogramaDto() { }

    public static OdontogramaDto FromDomain(Odontograma odontograma)
    {
        return new OdontogramaDto
        {
            Id = odontograma.Id,
            Dentes = odontograma.Dentes.Select(DenteDto.FromDomain).ToList()
        };
    }
}
