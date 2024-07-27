
using curifyapi.Models.Domain;
using curifyapi.Models.DTO;

namespace curifyapi.Extensions
{
    public static class UserDtoExtension
    {
        public static UserDto MapToDto(this User user)
        {
            return new UserDto
            {

                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            };
        }

        public static IEnumerable<UserDto> MapToDtos(this IEnumerable<User> users)
        {
            // Map a collection of User entities to UserDtos
            return users.Select(user => user.MapToDto());
        }
    }
}