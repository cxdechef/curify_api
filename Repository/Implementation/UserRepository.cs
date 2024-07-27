using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curifyapi.Data;
using curifyapi.Models.Domain;
using curifyapi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace curifyapi.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
 if (user == null)
 return null;

 if (await _db.Users.AnyAsync(u => u.Email == user.Email))
    {
        throw new Exception("Email already exists.");
    }
            user.Role = "user";
            user.Token = "";
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var existingUser = await _db.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = user.FirstName;
    existingUser.LastName = user.LastName;
    existingUser.Email = user.Email;

            await _db.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginUserAsync(string email)
        {
    return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}