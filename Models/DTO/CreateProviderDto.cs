

namespace curifyapi.Models.DTO
{
    public class CreateProviderDto
    {
        public string Name { get; set; } = "";
        public string Specialties { get; set; } = "";
        public string Location { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}