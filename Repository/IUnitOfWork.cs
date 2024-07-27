using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curifyapi.Repository.Interface;

namespace curifyapi.Repository
{
    public interface IUnitOfWork
    {

        IUserRepository UserRepository { get; }
        IProviderRepository ProviderRepository { get; }
        // Add properties for other repositories as needed

        Task SaveChangesAsync();
    }
}
