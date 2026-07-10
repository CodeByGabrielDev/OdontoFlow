using Application.Pacientes.DTOs;
using MediatR;

namespace Application.Pacientes.Queries.ListarPacientes;


public record ListarPacientesQuery(string? Nome,string? Cpf):IRequest<IEnumerable<PacienteResumoDto>>;

