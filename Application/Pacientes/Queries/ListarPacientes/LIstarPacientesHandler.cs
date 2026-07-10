using Application.Pacientes.DTOs;
using Domain.Entities.Pacientes;
using Domain.Interfaces;
using MediatR;

namespace Application.Pacientes.Queries.ListarPacientes;

public class ListarPacientesHandler : IRequestHandler<ListarPacientesQuery, IEnumerable<PacienteResumoDto>>
{
    private readonly IPacienteRepository _pacienteRepository;
    public ListarPacientesHandler(IPacienteRepository _pacienteRepository)
    {
        this._pacienteRepository = _pacienteRepository;
    }
    public async Task<IEnumerable<PacienteResumoDto>> Handle(ListarPacientesQuery listarPacientesQuery,CancellationToken cancellationToken)
    {
        IEnumerable<Paciente> pacientes = await this._pacienteRepository.ListarPacientesFiltradosAsync(listarPacientesQuery.Cpf,listarPacientesQuery.Nome);
        return pacientes.Select(p=> new PacienteResumoDto(p.Id,p.Nome,p.Cpf.Valor,p.Email.Valor,p.Ativo));
    }
}