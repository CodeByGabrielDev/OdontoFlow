using Domain.Interfaces;

namespace Infrastructure.Auth;


public class PasswordHasher : IPasswordHasher
{
    public string Hash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }
    public bool Verify(string senha, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(senha, hash);
    }
}