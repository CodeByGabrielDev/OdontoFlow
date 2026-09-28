using Domain.Entities.Prontuario;
using Domain.ValueObjects;

namespace Application.Prontuarios.DTOs;

public class DenteDto
{
    public Guid Id { get; private set; }
    public int Numero { get; private set; }
    public string Tipo { get; private set; } = string.Empty;
    public List<FaceDentalDto> Faces { get; private set; } = new();

    private DenteDto() { }

    public static DenteDto FromDomain(Dente dente)
    {
        return new DenteDto
        {
            Id = dente.Id,
            Numero = dente.Numero,
            Tipo = dente.Tipo,
            Faces = dente.StatusFaces.Select(FaceDentalDto.FromDomain).ToList()
        };
    }
}

public class FaceDentalDto
{
    public string Face { get; private set; } = string.Empty;
    public string Status { get; private set; } = string.Empty;

    private FaceDentalDto() { }

    public static FaceDentalDto FromDomain(FaceDental face)
    {
        return new FaceDentalDto
        {
            Face = face.Face,
            Status = face.Status
        };
    }
}
