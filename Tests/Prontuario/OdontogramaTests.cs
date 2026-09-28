using Domain.Entities.Prontuario;
using Domain.Exceptions;

namespace Tests.Prontuario;

public class OdontogramaTests
{
    [Fact]
    public void AdicionaDenteNaLista_DeveCriarTrintaEDoisDentes()
    {
        Odontograma odontograma = new Odontograma(Guid.NewGuid());

        odontograma.AdicionaDenteNaLista();

        Assert.Equal(32, odontograma.Dentes.Count);
    }

    [Fact]
    public void AdicionaDenteNaLista_ChamadoDuasVezes_DeveLancarDomainException()
    {
        Odontograma odontograma = new Odontograma(Guid.NewGuid());
        odontograma.AdicionaDenteNaLista();

        Assert.Throws<DomainException>(() => odontograma.AdicionaDenteNaLista());
    }
}
