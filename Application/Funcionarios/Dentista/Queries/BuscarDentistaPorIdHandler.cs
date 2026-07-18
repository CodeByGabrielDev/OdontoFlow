
using Application.Funcionarios.Dentista.DTOs;
using Domain.Interfaces;
using Domain.Entities.Funcionarios;
using MediatR;
using Application.Consultas.DTOs;
using Domain.Entities.Agenda;
using Domain.Exceptions;

namespace Application.Funcionarios.Dentista.Queries;


public class BuscarDentistaPorIdHandler : IRequestHandler<BuscarDentistaPorIdQuery, DentistaDto>
{
    private readonly IDentistaRepository _dentistaRepository;

    public BuscarDentistaPorIdHandler(IDentistaRepository _dentistaRepository)
    {
        this._dentistaRepository = _dentistaRepository;
    }

    public async Task<DentistaDto> Handle(BuscarDentistaPorIdQuery buscarDentistaPorIdQuery, CancellationToken cancellationToken)
    {
        Domain.Entities.Funcionarios.Dentista? dentista2 = await this._dentistaRepository.ObterDentistaPorIdAsync(buscarDentistaPorIdQuery.Id);
        if (dentista2 == null)
        {
            throw new DomainException("Dentista nao encontrado na base.");
        }
        DentistaDto dentistaDto = new DentistaDto(dentista2.Nome, dentista2.Cro.Uf, dentista2.Cro.Numero, dentista2.Email.Valor,
                                                  dentista2.Telefone.Valor, dentista2.Especialidade, dentista2.Ativo);
        if (dentista2.Consultas.Count == 0)
        {
            return dentistaDto;
        }
        foreach (Consulta consulta in dentista2.Consultas)
        {
            dentistaDto.ConsultaDtos.Add(new ConsultaDto(consulta.Paciente.Nome, dentistaDto.Nome,
                                                         consulta.Data, consulta.HoraInicio, consulta.HoraFim,
                                                         consulta.StatusConsulta.ToString(), consulta.Observacao, consulta.CriadoEm));
        }
        return dentistaDto;
    }
}