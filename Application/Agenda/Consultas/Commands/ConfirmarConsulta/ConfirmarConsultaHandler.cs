using Domain.Entities.Agenda;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Agenda.Consultas.Commands.ConfirmarConsulta;


public class ConfirmarConsultaHandler : IRequestHandler<ConfirmarConsultaCommand, Guid>
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ConfirmarConsultaHandler(IConsultaRepository _consultaRepository, IUnitOfWork _unitOfWork)
    {
        this._consultaRepository = _consultaRepository;
        this._unitOfWork = _unitOfWork;
    }

    public async Task<Guid> Handle(ConfirmarConsultaCommand confirmarConsultaCommand, CancellationToken cancellationToken)
    {
        Consulta? consulta = await this._consultaRepository.ObterPorIdAsync(confirmarConsultaCommand.Id);
        if (consulta == null)
        {
            throw new DomainException("Consulta nao encontrada na base de dados");
        }
        consulta.ConfirmarConsulta();
        await this._consultaRepository.UpdateAsync(consulta);
        await this._unitOfWork.SaveChangesAsync();
        return consulta.Id;

    }
}