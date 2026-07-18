using Domain.Entities.Agenda;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Agenda.Consultas.Commands.ConcluirConsulta;


public class ConcluirConsultaHandler : IRequestHandler<ConcluirConsultaCommand, Guid>
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ConcluirConsultaHandler(IConsultaRepository _consultaRepository, IUnitOfWork _unitOfWork)
    {
        this._consultaRepository = _consultaRepository;
        this._unitOfWork = _unitOfWork;
    }

    public async Task<Guid> Handle(ConcluirConsultaCommand concluirConsultaCommand, CancellationToken cancellationToken)
    {
        Consulta? consulta = await this._consultaRepository.ObterPorIdAsync(concluirConsultaCommand.Id);
        if (consulta == null)
        {
            throw new DomainException("Consulta nao encontrada na base ");
        }
        consulta.ConcluirConsulta();
        await this._consultaRepository.UpdateAsync(consulta);
        await this._unitOfWork.SaveChangesAsync();

        return consulta.Id;
    }
}