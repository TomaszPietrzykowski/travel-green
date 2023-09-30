using System.ComponentModel.DataAnnotations;

namespace TravelGreen.Models.Country
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
}
