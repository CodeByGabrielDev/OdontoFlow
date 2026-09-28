using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;

namespace Application.Funcionarios.Funcionario.Commands.CriarFuncionario;

public class CriarFuncionarioHandler : IRequestHandler<CriarFuncionarioCommand, Guid>
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarFuncionarioHandler(IFuncionarioRepository funcionarioRepository, IUnitOfWork unitOfWork)
    {
        this._funcionarioRepository = funcionarioRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CriarFuncionarioCommand command, CancellationToken cancellationToken)
    {
        Email email = new Email(command.Email);
        Telefone telefone = new Telefone(command.Telefone);
        Domain.Entities.Funcionarios.Funcionario funcionario = new Domain.Entities.Funcionarios.Funcionario(command.Nome, email, telefone, command.Perfil);
        await this._funcionarioRepository.AddAsync(funcionario);
        await this._unitOfWork.SaveChangesAsync();
        return funcionario.Id;
    }
}
