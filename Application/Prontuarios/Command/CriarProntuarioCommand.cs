using Application.Prontuarios.DTOs;
using MediatR;

namespace Application.Prontuarios.Command;


public record CriarProntuarioCommand(Guid IdPaciente):IRequest<ProntuarioDto>;
    
