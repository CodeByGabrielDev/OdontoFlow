using System.Reflection.Metadata;
using Domain.Interfaces;
using MediatR;

namespace Application.Pacientes.Commands.AtualizarPaciente;
public class AtualizarPacienteHandler : IRequestHandler<AtualizarPacienteCommand, Unit>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IUnitOfWork _unitOfWork;


    public AtualizarPacienteHandler(IPacienteRepository _pacienteRepository,IUnitOfWork _unitOfWork)
    {
        this._pacienteRepository = _pacienteRepository;
        this._unitOfWork = _unitOfWork;
    }

    public async Task Handle(AtualizarPacienteCommand atualizarPacienteCommand,CancellationToken cancellationToken)
    {
        
    }

}