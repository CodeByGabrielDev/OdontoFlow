using Domain.Exceptions;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;

namespace Application.Funcionarios.Dentista.Commands;


public class CriarDentistaHandler : IRequestHandler<CriarDentistaCommand, Guid>
{
    private readonly IDentistaRepository _dentistaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CriarDentistaHandler(IDentistaRepository _dentistaRepository, IUnitOfWork _unitOfWork)
    {
        this._dentistaRepository = _dentistaRepository;
        this._unitOfWork = _unitOfWork;
    }

    public async Task<Guid> Handle(CriarDentistaCommand criarDentistaCommand, CancellationToken cancellationToken)
    {
        bool existe = await this._dentistaRepository.ValidaExistenciaDeDentistaPorUfECro(criarDentistaCommand.UfCro, criarDentistaCommand.NumeroCro);
        if (existe)
        {
            throw new DomainException("Ja existe um dentista com essas credencias de CRO registrado no sistema");
        }
        Cro cro = new Cro(criarDentistaCommand.UfCro, criarDentistaCommand.NumeroCro);
        Email email = new Email(criarDentistaCommand.Email);
        Telefone telefone = new Telefone(criarDentistaCommand.Telefone);

        Domain.Entities.Funcionarios.Dentista dentista = new Domain.Entities.Funcionarios.Dentista(criarDentistaCommand.Nome, cro, email, telefone, criarDentistaCommand.Especialidade);

        await this._dentistaRepository.AddAsync(dentista);
        await this._unitOfWork.SaveChangesAsync();
        return dentista.Id;
    }

}