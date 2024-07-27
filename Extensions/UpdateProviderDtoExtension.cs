
using curifyapi.Models.Domain;
using curifyapi.Models.DTO;

namespace curifyapi.Extensions
{
    public static class UpdateProviderDtoExtension
    {
        public static void ApplyToProvider(this UpdateProviderDto updateProviderDto, Provider provider)
        {
            provider.Name = updateProviderDto.Name;
            provider.Specialties = updateProviderDto.Specialties;
            provider.Location = updateProviderDto.Location;
            provider.ImageUrl = updateProviderDto.ImageUrl;
            provider.Rating = updateProviderDto.Rating;
            provider.NumberOfReviews = updateProviderDto.NumberOfReviews;
        }
    }
}