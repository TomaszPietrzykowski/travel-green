using System.ComponentModel.DataAnnotations;

namespace TravelGreen.Models.Users
{
    public class ApiUserDto : LoginUserDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
