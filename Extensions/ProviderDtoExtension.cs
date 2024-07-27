
using curifyapi.Models.Domain;
using curifyapi.Models.DTO;

namespace curifyapi.Extensions
{
    public static class ProviderDtoExtension
    {
        public static ProviderDto MapToDto(this Provider provider)
        {
            return new ProviderDto
            {

                Id = provider.Id,
                Name = provider.Name,
                Specialties = provider.Specialties,
                Location = provider.Location,
                ImageUrl = provider.ImageUrl,
                Rating = provider.Rating,
                NumberOfReviews = provider.NumberOfReviews
            };
        }

        public static IEnumerable<ProviderDto> MapToDtos(this IEnumerable<Provider> providers)
        {
            return providers.Select(provider => provider.MapToDto());
        }
    }
}