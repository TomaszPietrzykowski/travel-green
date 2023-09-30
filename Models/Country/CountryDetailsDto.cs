using TravelGreen.Models.Hotel;

namespace TravelGreen.Models.Country
{
    public class CountryDetailsDto : BaseCountryDto
    {
        public int Id { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }
}
