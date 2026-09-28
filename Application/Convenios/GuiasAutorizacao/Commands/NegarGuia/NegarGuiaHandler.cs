using Domain.Entities.Convenios;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Convenios.GuiasAutorizacao.Commands.NegarGuia;

public class NegarGuiaHandler : IRequestHandler<NegarGuiaCommand, Guid>
{
    private readonly IGuiaAutorizacaoRepository _guiaAutorizacaoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public NegarGuiaHandler(IGuiaAutorizacaoRepository guiaAutorizacaoRepository, IUnitOfWork unitOfWork)
    {
        this._guiaAutorizacaoRepository = guiaAutorizacaoRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(NegarGuiaCommand command, CancellationToken cancellationToken)
    {
        GuiaAutorizacao? guia = await this._guiaAutorizacaoRepository.ObterPorIdAsync(command.GuiaId);
        if (guia == null) throw new DomainException("Guia de autorizacao nao encontrada na base de dados.");
        guia.Negar();
        await this._guiaAutorizacaoRepository.UpdateAsync(guia);
        await this._unitOfWork.SaveChangesAsync();
        return guia.Id;
    }
}
