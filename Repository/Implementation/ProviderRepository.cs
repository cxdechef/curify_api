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
    public class ProviderRepository : IProviderRepository
    {
         private readonly ApplicationDbContext _db;

        public ProviderRepository(ApplicationDbContext db)
        {
            _db = db;
        }


          public async Task<Provider> GetProviderByIdAsync(int id)
        {
            return await _db.Providers.FindAsync(id);
        }

  public async Task<IEnumerable<Provider>> GetAllProvidersAsync()
        {
            return await _db.Providers.ToListAsync();
        }


          public async Task<Provider> CreateProviderAsync(Provider provider)
        {
            await _db.Providers.AddAsync(provider);
            await _db.SaveChangesAsync();
            return provider;
        }


        
        public async Task<Provider> UpdateProviderAsync(int id, Provider provider)
        {
            var existingProvider = await _db.Providers.FindAsync(id);
            if (existingProvider == null)
            {
                return null;
            }

            existingProvider.Name = provider.Name;
            existingProvider.Specialties = provider.Specialties;
            existingProvider.Location = provider.Location;
            existingProvider.ImageUrl = provider.ImageUrl;


            await _db.SaveChangesAsync();
            return existingProvider;
        }


        public async Task<Provider> DeleteProviderAsync(int id)
        {
            var provider = await _db.Providers.FindAsync(id);
            if (provider == null)
            {
                return null;
            }

            _db.Providers.Remove(provider);
            await _db.SaveChangesAsync();
            return provider;
        }


    }
}