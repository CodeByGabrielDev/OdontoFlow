using Domain.Entities.Convenios;
using Domain.Enums;
using Domain.Exceptions;

namespace Tests.Convenios;

public class GuiaAutorizacaoTests
{
    [Fact]
    public void Autorizar_QuandoSolicitada_DeveMudarStatusParaAutorizado()
    {
        GuiaAutorizacao guia = new GuiaAutorizacao(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

        guia.Autorizar();

        Assert.Equal(StatusGuia.Autorizado, guia.Status);
    }

    [Fact]
    public void Autorizar_QuandoJaAutorizada_DeveLancarDomainException()
    {
        GuiaAutorizacao guia = new GuiaAutorizacao(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        guia.Autorizar();

        Assert.Throws<DomainException>(() => guia.Autorizar());
    }

    [Fact]
    public void Negar_QuandoSolicitada_DeveMudarStatusParaNegado()
    {
        GuiaAutorizacao guia = new GuiaAutorizacao(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

        guia.Negar();

        Assert.Equal(StatusGuia.Negado, guia.Status);
    }
}
