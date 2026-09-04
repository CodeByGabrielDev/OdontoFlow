using Application.Prontuarios.Command;
using Domain.Entities.Pacientes;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;

namespace Application.Pacientes.Commands.CadastrarPaciente;

public class CadastrarPacienteHandler: IRequestHandler<CadastrarPacienteCommand,Guid>
{
    private readonly IPacienteRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMediator _mediatr;

    public CadastrarPacienteHandler(IPacienteRepository _repository, IUnitOfWork _unitOfWork,IMediator _mediatr)
    {
        this._repository = _repository;
        this._unitOfWork = _unitOfWork;
        this._mediatr = _mediatr;
    }

    public async Task<Guid> Handle(CadastrarPacienteCommand cadastrarPacienteCommand,CancellationToken cancellationToken)
    {
        bool CpfJaCadastrado = await this._repository.CpfJaCadastradoAsync(cadastrarPacienteCommand.Cpf);

        if (CpfJaCadastrado)
        {
            throw new DomainException("CPF já cadastrado.");
        }
        var cpf = new Cpf(cadastrarPacienteCommand.Cpf);
        var email = new Email(cadastrarPacienteCommand.Email);
        var telefone = new Telefone(cadastrarPacienteCommand.Telefone);

        Paciente paciente = new Paciente(
            cadastrarPacienteCommand.Nome,cpf,email,telefone,cadastrarPacienteCommand.DataNascimento,cadastrarPacienteCommand.Sexo,cadastrarPacienteCommand.Endereco
        );
        await this._repository.AddAsync(paciente);
        await this._unitOfWork.SaveChangesAsync();
        await this._mediatr.Send(new CriarProntuarioCommand(paciente.Id));
        return paciente.Id;
    }
}