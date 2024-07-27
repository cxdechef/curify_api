

namespace curifyapi.Extensions.PasswordHasher
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string inputPassword, string hashPassword);
    }
}