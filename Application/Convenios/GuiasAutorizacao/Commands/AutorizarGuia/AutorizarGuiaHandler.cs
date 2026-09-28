using Domain.Entities.Convenios;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Convenios.GuiasAutorizacao.Commands.AutorizarGuia;

public class AutorizarGuiaHandler : IRequestHandler<AutorizarGuiaCommand, Guid>
{
    private readonly IGuiaAutorizacaoRepository _guiaAutorizacaoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AutorizarGuiaHandler(IGuiaAutorizacaoRepository guiaAutorizacaoRepository, IUnitOfWork unitOfWork)
    {
        this._guiaAutorizacaoRepository = guiaAutorizacaoRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AutorizarGuiaCommand command, CancellationToken cancellationToken)
    {
        GuiaAutorizacao? guia = await this._guiaAutorizacaoRepository.ObterPorIdAsync(command.GuiaId);
        if (guia == null) throw new DomainException("Guia de autorizacao nao encontrada na base de dados.");
        guia.Autorizar();
        await this._guiaAutorizacaoRepository.UpdateAsync(guia);
        await this._unitOfWork.SaveChangesAsync();
        return guia.Id;
    }
}
