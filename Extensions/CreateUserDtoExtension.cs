
using curifyapi.Models.Domain;
using curifyapi.Models.DTO;

namespace curifyapi.Extensions
{
    public static class CreateUserDtoExtension
    {
        public static User MapToUser(this CreateUserDto request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            return user;
        }

    }
}