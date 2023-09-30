using System.ComponentModel.DataAnnotations;

namespace TravelGreen.Models.Country
{
    public class UpdateCountryDto : BaseCountryDto 
    {
        [Required]
        public int Id { get; set; }
    }

}
