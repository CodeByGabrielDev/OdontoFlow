using Application.Prontuarios.DTOs;
using MediatR;

namespace Application.Prontuarios.Command.ProntuarioCommand;


public record CriarProntuarioCommand(Guid IdPaciente):IRequest<ProntuarioDto>;
    
