using Domain.Entities.Convenios;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Convenios.Convenios.Commands.AtivarDesativarConvenio;

public class DesativarConvenioHandler : IRequestHandler<DesativarConvenioCommand, Guid>
{
    private readonly IConvenioRepository _convenioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DesativarConvenioHandler(IConvenioRepository convenioRepository, IUnitOfWork unitOfWork)
    {
        this._convenioRepository = convenioRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(DesativarConvenioCommand command, CancellationToken cancellationToken)
    {
        Convenio? convenio = await this._convenioRepository.ObterPorIdAsync(command.ConvenioId);
        if (convenio == null) throw new DomainException("Convenio nao encontrado na base de dados.");
        convenio.Desativar();
        await this._convenioRepository.UpdateAsync(convenio);
        await this._unitOfWork.SaveChangesAsync();
        return convenio.Id;
    }
}
