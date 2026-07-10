using Application.Pacientes.DTOs;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Pacientes.Queries.ObterPacientePorId;


public class ObterPacienteHandler : IRequestHandler<ObterPacienteQuery, PacienteDto>
{
    private readonly IPacienteRepository _pacienteRepository;

    public ObterPacienteHandler(IPacienteRepository _pacienteRepository)
    {
        this._pacienteRepository = _pacienteRepository;
    }

    public async Task<PacienteDto> Handle(ObterPacienteQuery obterPacienteQuery, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(obterPacienteQuery.Id);
        if (paciente == null )
        {
            throw new DomainException("Id inexistente na base");
        }
        return new PacienteDto(paciente.Id,paciente.Nome,paciente.Cpf.Valor,paciente.Email.Valor,paciente.Telefone.Valor,
        paciente.DataNascimento,paciente.Sexo,paciente.Endereco,paciente.Ativo,paciente.CriadoEm);
    }
}