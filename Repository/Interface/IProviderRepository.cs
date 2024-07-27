using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curifyapi.Models.Domain;

namespace curifyapi.Repository.Interface
{
    public interface IProviderRepository
    {
    Task<Provider> GetProviderByIdAsync(int id);
    Task<IEnumerable<Provider>> GetAllProvidersAsync();
    Task<Provider> CreateProviderAsync(Provider provider);
    Task<Provider> UpdateProviderAsync(int id, Provider provider);
    Task<Provider> DeleteProviderAsync(int id); 
    }
}