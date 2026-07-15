using Application.Consultas.DTOs;
using Domain.Entities.Agenda;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Consultas.BuscarConsulta;

public class ObterConsultaPorIdHandler : IRequestHandler<ObterConsultaPorIdQuery, ConsultaDto>
{
    private readonly IConsultaRepository _consultaRepository;

    public ObterConsultaPorIdHandler(IConsultaRepository _consultaRepository)
    {
        this._consultaRepository = _consultaRepository;
    }

    public async Task<ConsultaDto> Handle(ObterConsultaPorIdQuery obterConsultaPorIdQuery, CancellationToken cancellationToken)
    {
        Consulta? consulta = await this._consultaRepository.ObterPorIdAsync(obterConsultaPorIdQuery.Id);
        if (consulta == null)
        {
            throw new DomainException("Não existe consulta no banco de dados com ese ID");
        }
        
        return new ConsultaDto(consulta.Paciente.Nome, consulta.Dentista.Nome, consulta.Data, consulta.HoraInicio, consulta.HoraFim, consulta.StatusConsulta.ToString(), consulta.Observacao, consulta.CriadoEm);
    }

}