

namespace curifyapi.Models.DTO
{
    public class UpdateProviderDto
    {
        public string Name { get; set; } = "";
        public string Specialties { get; set; } = "";
        public string Location { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int Rating { get; set; }
        public int NumberOfReviews { get; set; }
    }
}