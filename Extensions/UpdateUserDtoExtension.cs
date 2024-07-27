
using curifyapi.Models.Domain;
using curifyapi.Models.DTO;

namespace curifyapi.Extensions
{
    public static class UpdateUserDtoExtension
    {
        public static void ApplyToUser(this UpdateUserDto updateUserDto, User user)
        {
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Email = updateUserDto.Email;
        }

    }
}