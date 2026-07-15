using System.Reflection.Metadata;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Pacientes.Commands.AtualizarPaciente;

public class AtualizarPacienteHandler : IRequestHandler<AtualizarPacienteCommand, Unit>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AtualizarPacienteHandler(IPacienteRepository _pacienteRepository, IUnitOfWork _unitOfWork)
    {
        this._pacienteRepository = _pacienteRepository;
        this._unitOfWork = _unitOfWork;
    }
    public async Task<Unit> Handle(AtualizarPacienteCommand atualizarPacienteCommand, CancellationToken cancellationToken)
    {
        Paciente? paciente = await this._pacienteRepository.ObterPorIdAsync(atualizarPacienteCommand.Id);
        if (paciente == null)
        {
            throw new DomainException("Paciente inexistente na base");
        }
        paciente.AtualizarDados(atualizarPacienteCommand.Nome,atualizarPacienteCommand.Email,atualizarPacienteCommand.Telefone,
                                atualizarPacienteCommand.Sexo,atualizarPacienteCommand.Endereco);
        await this._pacienteRepository.Update(paciente);
        await this._unitOfWork.SaveChangesAsync();
        return Unit.Value;
    }

}