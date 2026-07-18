using Domain.Entities.Funcionarios;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Funcionarios.Usuarios.CriarUsuario;


public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioCommand, Guid>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public CriarUsuarioHandler(IUsuarioRepository _usuarioRepository, IPasswordHasher _passwordHasher, IUnitOfWork _unitOfWork)
    {
        this._usuarioRepository = _usuarioRepository;
        this._passwordHasher = _passwordHasher;
        this._unitOfWork = _unitOfWork;
    }


    public async Task<Guid> Handle(CriarUsuarioCommand criarUsuarioCommand, CancellationToken cancellationToken)
    {
        Domain.Entities.Funcionarios.Usuario usuarios = await this._usuarioRepository.ObterPorEmailAsync(criarUsuarioCommand.Email);
        if (usuarios != null)
        {
            throw new DomainException("Usuario ja existente com esse email");
        }
        if (!Enum.TryParse<TipoPerfil>(criarUsuarioCommand.Perfil, out var result))
        {
            throw new DomainException("Perfil inexistente");
        }
        Email email = new Email(criarUsuarioCommand.Email);
        Usuario usuario = new Usuario(criarUsuarioCommand.Nome, email, this._passwordHasher.Hash(criarUsuarioCommand.Senha), result);
        await this._usuarioRepository.AddAsync(usuario);
        await this._unitOfWork.SaveChangesAsync();
        return usuario.Id;


    }
}