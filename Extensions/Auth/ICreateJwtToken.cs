
using curifyapi.Models.Domain;

namespace curifyapi.Extensions.Auth
{
    public interface ICreateJwtToken
    {
        string GenerateToken(User user);
    }
}