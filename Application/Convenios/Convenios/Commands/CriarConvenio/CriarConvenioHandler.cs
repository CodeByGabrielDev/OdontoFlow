using Domain.Entities.Convenios;
using Domain.Interfaces;
using MediatR;

namespace Application.Convenios.Convenios.Commands.CriarConvenio;

public class CriarConvenioHandler : IRequestHandler<CriarConvenioCommand, Guid>
{
    private readonly IConvenioRepository _convenioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarConvenioHandler(IConvenioRepository convenioRepository, IUnitOfWork unitOfWork)
    {
        this._convenioRepository = convenioRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CriarConvenioCommand command, CancellationToken cancellationToken)
    {
        Convenio convenio = new Convenio(command.Nome, command.Operadora);
        await this._convenioRepository.AddAsync(convenio);
        await this._unitOfWork.SaveChangesAsync();
        return convenio.Id;
    }
}
