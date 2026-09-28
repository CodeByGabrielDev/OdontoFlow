using Domain.Entities.Prontuario;

namespace Tests.Prontuario;

public class DenteTests
{
    [Fact]
    public void Construtor_DeveCriarDenteComCincoFacesSemLancarExcecao()
    {
        Dente dente = new Dente(Guid.NewGuid(), 1, "Incisivo Central");

        Assert.Equal(5, dente.StatusFaces.Count);
    }
}
