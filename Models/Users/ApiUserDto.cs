using System.ComponentModel.DataAnnotations;

namespace TravelGreen.Models.Users
{
    public class ApiUserDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Your password must be {2} to {1} characters long", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
