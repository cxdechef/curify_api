using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curifyapi.Data;
using curifyapi.Repository.Implementation;
using curifyapi.Repository.Interface;

namespace curifyapi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;  // Replaced _context with _db

        public UnitOfWork(ApplicationDbContext db)  // Replaced _context with _db in constructor
        {
            _db = db;  // Replaced _context with _db
        }

        public IUserRepository UserRepository => new UserRepository(_db);  // Replaced _context with _db
        public IProviderRepository ProviderRepository => new ProviderRepository(_db);  // Replaced _context with _db
        // Add properties for other repositories as needed

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();  // Replaced _context with _db
        }

        
    }
}