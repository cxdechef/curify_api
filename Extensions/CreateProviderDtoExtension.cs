
using curifyapi.Models.Domain;
using curifyapi.Models.DTO;

namespace curifyapi.Extensions
{
    public static class CreateProviderDtoExtension
    {
        public static Provider MapToProvider(this CreateProviderDto request)
        {
            var provider = new Provider
            {
                Name = request.Name,
                Specialties = request.Specialties,
                Location = request.Location,
                ImageUrl = request.ImageUrl
            };

            return provider;
        }
    }
}