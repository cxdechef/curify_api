

using curifyapi.Models.Domain;

namespace curifyapi.Repository.Interface
{
    public interface IUserRepository
    {
    Task<User> GetUserByIdAsync(int id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(int id, User user);
    Task<User> DeleteUserAsync(int id); 
    Task<User> LoginUserAsync(string email);


    }
}